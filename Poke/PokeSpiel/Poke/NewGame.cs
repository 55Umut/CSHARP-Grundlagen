using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Poke
{
    public class NewGame
    {
        private readonly TrainerData trainerData;
        private readonly PokemonsData pokemonsData;
        private readonly DataBaseConnection dbConnection;
        private readonly Anzeige anzeige;
        private readonly GameEngine gameEngine;

        public NewGame(TrainerData trainerData, PokemonsData pokemonsData, DataBaseConnection dbConnection, Anzeige anzeige, GameEngine gameEngine)
        {
            this.trainerData = trainerData;
            this.pokemonsData = pokemonsData;
            this.dbConnection = dbConnection;
            this.anzeige = anzeige;
            this.gameEngine = gameEngine;
        }

        public void StartNewGame(string username)
        {
            Console.Clear();
            Console.WriteLine($"Willkommen, {username}!\n");
            Console.WriteLine("++++ Neues Spiel starten ++++\n");

            int trainerId = SelectOrCreateTrainer();
            if (trainerId == -1)
            {
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            int pokemonId = SelectPokemon();
            if (pokemonId == -1)
            {
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            int userId = GetUserId(username);
            if (userId == -1)
            {
                Console.WriteLine("Fehler: Benutzer-ID konnte nicht gefunden werden.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            SaveGameProgress(userId, trainerId, pokemonId, 1, 0, 1, 0);

            try
            {
                dbConnection.AddTrainerPokemon(trainerId, pokemonId, 1);
                Console.WriteLine($"\nPokémon mit ID {pokemonId} wurde Trainer mit ID {trainerId} zugewiesen!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Zuweisen des Pokémon: {ex.Message}");
            }

            Console.WriteLine("\nNeues Spiel erfolgreich gestartet!");
            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();

            GameMenu(username, userId, trainerId, pokemonId);
        }

        public void LoadGameProgress(string username)
        {
            int userId = GetUserId(username);
            if (userId == -1)
            {
                Console.WriteLine("Fehler: Benutzer-ID konnte nicht gefunden werden.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine($"Spielstände für {username}:\n");

            List<(int Id, int TrainerId, int PokemonId, int TrainerLevel, int TrainerExp, int PokemonLevel, int PokemonExp, DateTime CreatedAt)> gameProgressList = new List<(int, int, int, int, int, int, int, DateTime)>();

            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, trainer_id, pokemon_id, trainer_level, trainer_exp, pokemon_level, pokemon_exp, created_at " +
                                   "FROM game_progress WHERE user_id = @userId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gameProgressList.Add((
                                    reader.GetInt32("id"),
                                    reader.GetInt32("trainer_id"),
                                    reader.GetInt32("pokemon_id"),
                                    reader.GetInt32("trainer_level"),
                                    reader.GetInt32("trainer_exp"),
                                    reader.GetInt32("pokemon_level"),
                                    reader.GetInt32("pokemon_exp"),
                                    reader.GetDateTime("created_at")
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Laden der Spielstände: {ex.Message}");
                    Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                    Console.ReadKey();
                    return;
                }
            }

            if (gameProgressList.Count == 0)
            {
                Console.WriteLine("Keine Spielstände gefunden.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < gameProgressList.Count; i++)
            {
                var progress = gameProgressList[i];
                string trainerName = GetTrainerName(progress.TrainerId);
                string pokemonName = GetPokemonName(progress.PokemonId);
                Console.WriteLine($"{i + 1}. Spielstand ID: {progress.Id}");
                Console.WriteLine($"   Trainer: {trainerName} (Level: {progress.TrainerLevel}, EXP: {progress.TrainerExp})");
                Console.WriteLine($"   Pokémon: {pokemonName} (Level: {progress.PokemonLevel}, EXP: {progress.PokemonExp})");
                Console.WriteLine($"   Erstellt: {progress.CreatedAt}");
                Console.WriteLine();
            }

            Console.Write("Wählen Sie einen Spielstand (1-{0}, oder 0 zum Abbrechen): ", gameProgressList.Count);
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > gameProgressList.Count)
            {
                Console.WriteLine("Ungültige Auswahl.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            if (choice == 0)
            {
                return;
            }

            var selectedProgress = gameProgressList[choice - 1];
            Console.WriteLine($"\nSpielstand geladen: Trainer {GetTrainerName(selectedProgress.TrainerId)}, Pokémon {GetPokemonName(selectedProgress.PokemonId)}");
            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();

            GameMenu(username, userId, selectedProgress.TrainerId, selectedProgress.PokemonId);
        }

        public void DeleteGameProgress(string username)
        {
            int userId = GetUserId(username);
            if (userId == -1)
            {
                Console.WriteLine("Fehler: Benutzer-ID konnte nicht gefunden werden.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine($"Spielstände für {username}:\n");

            List<(int Id, int TrainerId, int PokemonId, DateTime CreatedAt)> gameProgressList = new List<(int, int, int, DateTime)>();

            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, trainer_id, pokemon_id, created_at FROM game_progress WHERE user_id = @userId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gameProgressList.Add((
                                    reader.GetInt32("id"),
                                    reader.GetInt32("trainer_id"),
                                    reader.GetInt32("pokemon_id"),
                                    reader.GetDateTime("created_at")
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Laden der Spielstände: {ex.Message}");
                    Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                    Console.ReadKey();
                    return;
                }
            }

            if (gameProgressList.Count == 0)
            {
                Console.WriteLine("Keine Spielstände gefunden.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < gameProgressList.Count; i++)
            {
                var progress = gameProgressList[i];
                string trainerName = GetTrainerName(progress.TrainerId);
                string pokemonName = GetPokemonName(progress.PokemonId);
                Console.WriteLine($"{i + 1}. Spielstand ID: {progress.Id}");
                Console.WriteLine($"   Trainer: {trainerName}");
                Console.WriteLine($"   Pokémon: {pokemonName}");
                Console.WriteLine($"   Erstellt: {progress.CreatedAt}");
                Console.WriteLine();
            }

            Console.Write("Wählen Sie einen Spielstand zum Löschen (1-{0}, oder 0 zum Abbrechen): ", gameProgressList.Count);
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > gameProgressList.Count)
            {
                Console.WriteLine("Ungültige Auswahl.");
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
                return;
            }

            if (choice == 0)
            {
                return;
            }

            int progressId = gameProgressList[choice - 1].Id;
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM game_progress WHERE id = @progressId AND user_id = @userId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@progressId", progressId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Spielstand erfolgreich gelöscht.");
                        }
                        else
                        {
                            Console.WriteLine("Fehler: Spielstand konnte nicht gelöscht werden.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Löschen des Spielstands: {ex.Message}");
                }
            }

            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }

        private int SelectOrCreateTrainer()
        {
            Console.WriteLine("Bitte wähle einen Trainer:\n");
            var trainers = trainerData.GetRandomTrainers(3);
            for (int i = 0; i < trainers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {trainers[i].Id}, Name: {trainers[i].Name}, Region: {trainers[i].Region}, Mission: {trainers[i].Mission}");
            }
            Console.WriteLine("4. Neuen Trainer erstellen");
            Console.Write("\nBitte wählen (1-4): ");

            string choice = Console.ReadLine();
            if (choice == "4")
            {
                Console.WriteLine("\nNeuen Trainer erstellen:");
                Console.Write("Trainername: ");
                string name = Console.ReadLine();
                Console.Write("Region: ");
                string region = Console.ReadLine();
                Console.Write("Mission: ");
                string mission = Console.ReadLine();
                Console.Write("Level (z. B. 1): ");
                if (!int.TryParse(Console.ReadLine(), out int level))
                {
                    Console.WriteLine("Ungültiges Level.");
                    return -1;
                }
                Console.Write("Erfahrung (z. B. 0): ");
                if (!int.TryParse(Console.ReadLine(), out int experience))
                {
                    Console.WriteLine("Ungültige Erfahrung.");
                    return -1;
                }

                trainerData.InsertTrainer(name, region, mission, level, experience);

                using (var connection = dbConnection.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT id FROM trainer WHERE name = @name AND region = @region AND mission = @mission ORDER BY id DESC LIMIT 1";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@region", region);
                            cmd.Parameters.AddWithValue("@mission", mission);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                int trainerId = Convert.ToInt32(result);
                                Console.WriteLine($"Neuer Trainer {name} erstellt mit ID {trainerId}.");
                                return trainerId;
                            }
                            else
                            {
                                Console.WriteLine("Fehler beim Abrufen der Trainer-ID.");
                                return -1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fehler beim Erstellen des Trainers: {ex.Message}");
                        return -1;
                    }
                }
            }
            else if (int.TryParse(choice, out int choiceNum) && choiceNum >= 1 && choiceNum <= 3)
            {
                int trainerId = trainers[choiceNum - 1].Id;
                Console.WriteLine($"Trainer {trainers[choiceNum - 1].Name} ausgewählt.");
                return trainerId;
            }
            else
            {
                Console.WriteLine("Ungültige Auswahl.");
                return -1;
            }
        }

        private int SelectPokemon()
        {
            Console.WriteLine("\nBitte wähle ein Pokémon:\n");
            pokemonsData.ReadPoke();
            Console.Write("Geben Sie die ID des gewünschten Pokémon ein: ");
            if (!int.TryParse(Console.ReadLine(), out int pokemonId))
            {
                Console.WriteLine("Ungültige Pokémon-ID.");
                return -1;
            }

            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM pokemons WHERE id = @pokemonId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("Pokémon mit dieser ID existiert nicht.");
                            return -1;
                        }
                        return pokemonId;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Überprüfen des Pokémon: {ex.Message}");
                    return -1;
                }
            }
        }

        private int GetUserId(string username)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id FROM users WHERE username = @username";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        Console.WriteLine("Benutzer nicht gefunden.");
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Abrufen der Benutzer-ID: {ex.Message}");
                    return -1;
                }
            }
        }

        private void SaveGameProgress(int userId, int trainerId, int pokemonId, int trainerLevel, int trainerExp, int pokemonLevel, int pokemonExp)
        {
            string query = "INSERT INTO game_progress (user_id, trainer_id, pokemon_id, trainer_level, trainer_exp, pokemon_level, pokemon_exp, created_at) " +
                          "VALUES (@userId, @trainerId, @pokemonId, @trainerLevel, @trainerExp, @pokemonLevel, @pokemonExp, NOW()) " +
                          "ON DUPLICATE KEY UPDATE trainer_level = @trainerLevel, trainer_exp = @trainerExp, pokemon_level = @pokemonLevel, pokemon_exp = @pokemonExp";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@userId", userId),
                new MySqlParameter("@trainerId", trainerId),
                new MySqlParameter("@pokemonId", pokemonId),
                new MySqlParameter("@trainerLevel", trainerLevel),
                new MySqlParameter("@trainerExp", trainerExp),
                new MySqlParameter("@pokemonLevel", pokemonLevel),
                new MySqlParameter("@pokemonExp", pokemonExp)
            };

            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Spielstand erfolgreich gespeichert.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Speichern des Spielstands: {ex.Message}");
                }
            }
        }

        private string GetTrainerName(int trainerId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM trainer WHERE id = @trainerId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@trainerId", trainerId);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Unbekannt";
                    }
                }
                catch (Exception)
                {
                    return "Unbekannt";
                }
            }
        }

        private string GetPokemonName(int pokemonId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM pokemons WHERE id = @pokemonId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Unbekannt";
                    }
                }
                catch (Exception)
                {
                    return "Unbekannt";
                }
            }
        }

        private void GameMenu(string username, int userId, int trainerId, int pokemonId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Spielmenü für {username}");
                Console.WriteLine($"Trainer: {GetTrainerName(trainerId)}");
                Console.WriteLine($"Pokémon: {GetPokemonName(pokemonId)}\n");
                Console.WriteLine("1. Kampf starten");
                Console.WriteLine("2. Pokémon anzeigen");
                Console.WriteLine("3. Trainer anzeigen");
                Console.WriteLine("4. Spielstand speichern");
                Console.WriteLine("5. Zurück zum Hauptmenü");
                Console.Write("\nBitte wählen Sie eine Option (1-5): ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        gameEngine.StartBattle(trainerId, pokemonId);
                        break;
                    case "2":
                        pokemonsData.ReadPoke();
                        break;
                    case "3":
                        trainerData.ReadTrainers();
                        break;
                    case "4":
                        Console.WriteLine("Spielstand wird gespeichert...");
                        using (var connection = dbConnection.GetConnection())
                        {
                            try
                            {
                                connection.Open();
                                string query = "SELECT trainer_level, trainer_exp, pokemon_level, pokemon_exp FROM game_progress WHERE user_id = @userId AND trainer_id = @trainerId AND pokemon_id = @pokemonId";
                                using (var cmd = new MySqlCommand(query, connection))
                                {
                                    cmd.Parameters.AddWithValue("@userId", userId);
                                    cmd.Parameters.AddWithValue("@trainerId", trainerId);
                                    cmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            int trainerLevel = reader.GetInt32("trainer_level");
                                            int trainerExp = reader.GetInt32("trainer_exp");
                                            int pokemonLevel = reader.GetInt32("pokemon_level");
                                            int pokemonExp = reader.GetInt32("pokemon_exp");
                                            SaveGameProgress(userId, trainerId, pokemonId, trainerLevel, trainerExp, pokemonLevel, pokemonExp);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Fehler: Spielstand nicht gefunden. Neuer Spielstand wird erstellt.");
                                            SaveGameProgress(userId, trainerId, pokemonId, 1, 0, 1, 0);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Fehler beim Abrufen des Spielstands: {ex.Message}");
                            }
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }
                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                Console.ReadKey();
            }
        }
    }
}
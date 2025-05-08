using MySql.Data.MySqlClient;
using System;

namespace Poke
{
    public class DataBaseConnection
    {
        private readonly string connectionString;

        public DataBaseConnection()
        {
            connectionString = "Server=localhost;Database=pokedex;User=root;Password=;Charset=utf8;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Abfrage erfolgreich ausgeführt.");
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1045)
                {
                    Console.WriteLine("Datenbankzugriff verweigert: Überprüfen Sie Benutzername und Passwort.");
                }
                catch (MySqlException ex) when (ex.Number == 1049)
                {
                    Console.WriteLine("Datenbank 'pokedex' nicht gefunden.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}");
                }
            }
        }

        public MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            var connection = GetConnection();
            try
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (MySqlException ex) when (ex.Number == 1045)
            {
                Console.WriteLine("Datenbankzugriff verweigert: Überprüfen Sie Benutzername und Passwort.");
                return null;
            }
            catch (MySqlException ex) when (ex.Number == 1049)
            {
                Console.WriteLine("Datenbank 'pokedex' nicht gefunden.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
                connection.Dispose();
                return null;
            }
        }

        public void AddUser(string username, string password, string email)
        {
            string query = "INSERT INTO users (username, password, email, created_at, last_login) VALUES (@username, @password, @email, NOW(), NOW())";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password),
                new MySqlParameter("@email", email)
            };
            ExecuteQuery(query, parameters);
        }

        public void AddTrainer(string name, string region, string mission, int level, int experience)
        {
            string query = "INSERT INTO trainer (name, region, mission, level, experience) VALUES (@name, @region, @mission, @level, @experience)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@name", name),
                new MySqlParameter("@region", region),
                new MySqlParameter("@mission", mission),
                new MySqlParameter("@level", level),
                new MySqlParameter("@experience", experience)
            };
            ExecuteQuery(query, parameters);
        }

        public void AddTrainerPokemon(int trainerId, int pokemonId, int slot)
        {
            string query = "INSERT INTO trainer_pokemon (trainer_id, pokemon_id, slot) VALUES (@trainerId, @pokemonId, @slot)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@trainerId", trainerId),
                new MySqlParameter("@pokemonId", pokemonId),
                new MySqlParameter("@slot", slot)
            };
            ExecuteQuery(query, parameters);
        }

        public void AddRegion(string name, string description)
        {
            string query = "INSERT INTO regionen (name, description) VALUES (@name, @description)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@name", name),
                new MySqlParameter("@description", description)
            };
            ExecuteQuery(query, parameters);
        }

        public void ReadUsers()
        {
            string query = "SELECT * FROM users";
            using (var reader = ExecuteReader(query))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Benutzername: {reader["username"]}, E-Mail: {reader["email"]}, Erstellt am: {reader["created_at"]}, Letztes Login: {reader["last_login"]}");
                    }
                }
            }
        }

        public void ReadTrainers()
        {
            string query = "SELECT * FROM trainer";
            using (var reader = ExecuteReader(query))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Region: {reader["region"]}, Mission: {reader["mission"]}, Level: {reader["level"]}, Erfahrung: {reader["experience"]}");
                    }
                }
            }
        }

        public void ReadTrainerPokemons(int trainerId)
        {
            string query = "SELECT * FROM trainer_pokemon WHERE trainer_id = @trainerId";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@trainerId", trainerId)
            };
            using (var reader = ExecuteReader(query, parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Trainer ID: {reader["trainer_id"]}, Pomekon ID: {reader["pokemon_id"]}, Slot: {reader["slot"]}");
                    }
                }
            }
        }

        public void ReadRegions()
        {
            string query = "SELECT * FROM regionen";
            using (var reader = ExecuteReader(query))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Region: {reader["name"]}, Beschreibung: {reader["description"]}");
                    }
                }
            }
        }
    }
}
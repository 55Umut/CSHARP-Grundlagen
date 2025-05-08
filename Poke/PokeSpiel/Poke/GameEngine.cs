using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poke
{
    public class GameEngine
    {
        private readonly PokemonsData pokemonsData;
        private readonly DataBaseConnection dbConnection;
        private readonly Random random;

        public GameEngine(PokemonsData pokemonsData, DataBaseConnection dbConnection)
        {
            this.pokemonsData = pokemonsData;
            this.dbConnection = dbConnection;
            this.random = new Random();
        }

        public void StartBattle(int trainerId, int playerPokemonId)
        {
            Console.Clear();
            Console.WriteLine("++++ Kampf starten ++++\n");

            var playerPokemon = GetPokemonDetails(playerPokemonId);
            if (playerPokemon == null)
            {
                Console.WriteLine("Fehler: Spieler-Pokémon nicht gefunden.");
                return;
            }

            var wildPokemon = GetRandomWildPokemon();
            if (wildPokemon == null)
            {
                Console.WriteLine("Fehler: Kein wildes Pokémon verfügbar.");
                return;
            }

            Console.WriteLine($"Ein wildes {wildPokemon.Name} (Level {wildPokemon.Level}, HP {wildPokemon.Lebenspunkte}) erscheint!");
            Console.WriteLine($"Dein Pokémon: {playerPokemon.Name} (Level {playerPokemon.Level}, HP {playerPokemon.Lebenspunkte})\n");

            bool playerTurn = random.Next(0, 2) == 0;
            int playerHp = playerPokemon.Lebenspunkte;
            int wildHp = wildPokemon.Lebenspunkte;

            while (playerHp > 0 && wildHp > 0)
            {
                if (playerTurn)
                {
                    Console.WriteLine("Wähle eine Attacke:");
                    if (!string.IsNullOrEmpty(playerPokemon.Attacke1))
                        Console.WriteLine($"1. {playerPokemon.Attacke1} (Schaden: {playerPokemon.SchadenAttacke1})");
                    if (!string.IsNullOrEmpty(playerPokemon.Attacke2))
                        Console.WriteLine($"2. {playerPokemon.Attacke2} (Schaden: {playerPokemon.SchadenAttacke2})");
                    if (!string.IsNullOrEmpty(playerPokemon.Spezialattacke))
                        Console.WriteLine($"3. {playerPokemon.Spezialattacke} (Schaden: {playerPokemon.SchadenSpezialattacke})");
                    Console.Write("Auswahl (1-3): ");

                    string choice = Console.ReadLine();
                    int damage = 0;
                    string attackName = "";
                    if (choice == "1" && !string.IsNullOrEmpty(playerPokemon.Attacke1))
                    {
                        damage = playerPokemon.SchadenAttacke1 ?? 0;
                        attackName = playerPokemon.Attacke1;
                    }
                    else if (choice == "2" && !string.IsNullOrEmpty(playerPokemon.Attacke2))
                    {
                        damage = playerPokemon.SchadenAttacke2 ?? 0;
                        attackName = playerPokemon.Attacke2;
                    }
                    else if (choice == "3" && !string.IsNullOrEmpty(playerPokemon.Spezialattacke))
                    {
                        damage = playerPokemon.SchadenSpezialattacke ?? 0;
                        attackName = playerPokemon.Spezialattacke;
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Auswahl.");
                        continue;
                    }

                    wildHp -= damage;
                    Console.WriteLine($"{playerPokemon.Name} verwendet {attackName}! {wildPokemon.Name} erleidet {damage} Schaden. (HP: {Math.Max(0, wildHp)})");
                }
                else
                {
                    var attacks = new List<(string Name, int? Damage)>
                    {
                        (wildPokemon.Attacke1, wildPokemon.SchadenAttacke1),
                        (wildPokemon.Attacke2, wildPokemon.SchadenAttacke2),
                        (wildPokemon.Spezialattacke, wildPokemon.SchadenSpezialattacke)
                    }.Where(a => !string.IsNullOrEmpty(a.Name) && a.Damage.HasValue).ToList();

                    if (attacks.Count == 0)
                    {
                        Console.WriteLine($"{wildPokemon.Name} hat keine gültigen Attacken.");
                        break;
                    }

                    var attack = attacks[random.Next(attacks.Count)];
                    int damage = attack.Damage ?? 0;
                    playerHp -= damage;
                    Console.WriteLine($"{wildPokemon.Name} verwendet {attack.Name}! {playerPokemon.Name} erleidet {damage} Schaden. (HP: {Math.Max(0, playerHp)})");
                }

                playerTurn = !playerTurn;
                Console.WriteLine();
            }

            if (playerHp <= 0)
            {
                Console.WriteLine($"{playerPokemon.Name} wurde besiegt! Du bist geflüchtet.");
            }
            else
            {
                Console.WriteLine($"Wildes {wildPokemon.Name} wurde besiegt!");
                int expGain = 50;
                int newExp = playerPokemon.Exp + expGain;
                int newLevel = playerPokemon.Level;
                int maxExp = playerPokemon.MaxExp;

                while (newExp >= maxExp && newLevel < 100)
                {
                    newLevel++;
                    newExp -= maxExp;
                    maxExp = (int)(maxExp * 1.1);
                    Console.WriteLine($"{playerPokemon.Name} ist auf Level {newLevel} gestiegen!");
                }

                UpdatePokemonProgress(playerPokemonId, newLevel, newExp, maxExp);
                Console.WriteLine($"{playerPokemon.Name} erhält {expGain} EXP. (Neuer EXP: {newExp}/{maxExp})");
            }

            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }

        private Pokemon GetPokemonDetails(int pokemonId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name, level, lebenspunkte, attacke1, schaden_attacke1, attacke2, schaden_attacke2, " +
                                   "spezialattacke, schaden_spezialattacke, exp, max_exp " +
                                   "FROM pokemons WHERE id = @pokemonId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var pokemon = new Pokemon
                                {
                                    Id = pokemonId,
                                    Name = reader.GetString("name"),
                                    Level = reader.GetInt32("level"),
                                    Lebenspunkte = reader.GetInt32("lebenspunkte"),
                                    Attacke1 = reader.IsDBNull(reader.GetOrdinal("attacke1")) ? null : reader.GetString("attacke1"),
                                    Attacke2 = reader.IsDBNull(reader.GetOrdinal("attacke2")) ? null : reader.GetString("attacke2"),
                                    Spezialattacke = reader.IsDBNull(reader.GetOrdinal("spezialattacke")) ? null : reader.GetString("spezialattacke"),
                                    Exp = reader.GetInt32("exp"),
                                    MaxExp = reader.GetInt32("max_exp")
                                };

                                pokemon.SchadenAttacke1 = reader.IsDBNull(reader.GetOrdinal("schaden_attacke1")) ? null : (int?)reader.GetInt32("schaden_attacke1");
                                pokemon.SchadenAttacke2 = reader.IsDBNull(reader.GetOrdinal("schaden_attacke2")) ? null : (int?)reader.GetInt32("schaden_attacke2");
                                pokemon.SchadenSpezialattacke = reader.IsDBNull(reader.GetOrdinal("schaden_spezialattacke")) ? null : (int?)reader.GetInt32("schaden_spezialattacke");

                                return pokemon;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Laden des Pokémon: {ex.Message}");
                }
                return null;
            }
        }

        private Pokemon GetRandomWildPokemon()
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id FROM pokemons";
                    List<int> pokemonIds = new List<int>();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pokemonIds.Add(reader.GetInt32("id"));
                            }
                        }
                    }

                    if (pokemonIds.Count == 0)
                        return null;

                    int randomPokemonId = pokemonIds[random.Next(pokemonIds.Count)];
                    return GetPokemonDetails(randomPokemonId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Auswählen eines wilden Pokémon: {ex.Message}");
                    return null;
                }
            }
        }

        private void UpdatePokemonProgress(int pokemonId, int level, int exp, int maxExp)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE pokemons SET level = @level, exp = @exp, max_exp = @maxExp WHERE id = @pokemonId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@level", level);
                        cmd.Parameters.AddWithValue("@exp", exp);
                        cmd.Parameters.AddWithValue("@maxExp", maxExp);
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        cmd.ExecuteNonQuery();
                    }

                    query = "UPDATE game_progress SET pokemon_level = @level, pokemon_exp = @exp WHERE pokemon_id = @pokemonId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@level", level);
                        cmd.Parameters.AddWithValue("@exp", exp);
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Aktualisieren des Pokémon-Fortschritts: {ex.Message}");
                }
            }
        }
    }

    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Lebenspunkte { get; set; }
        public string Attacke1 { get; set; }
        public int? SchadenAttacke1 { get; set; }
        public string Attacke2 { get; set; }
        public int? SchadenAttacke2 { get; set; }
        public string Spezialattacke { get; set; }
        public int? SchadenSpezialattacke { get; set; }
        public int Exp { get; set; }
        public int MaxExp { get; set; }
    }
}
using MySql.Data.MySqlClient;
using System;

namespace Poke
{
    public class PokemonsData
    {
        private readonly DataBaseConnection dbConnection;

        public PokemonsData()
        {
            dbConnection = new DataBaseConnection();
        }

        public void ReadPoke()
        {
            string query = "SELECT id, name, level, lebenspunkte, attacke1, schaden_attacke1, attacke2, schaden_attacke2, spezialattacke, schaden_spezialattacke, exp, max_exp FROM pokemons";
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n++++ Liste der Pomekon ++++\n");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Level: {reader["level"]}, HP: {reader["lebenspunkte"]}, " +
                                              $"Attacke 1: {reader["attacke1"]}, Schaden 1: {reader["schaden_attacke1"]}, " +
                                              $"Attacke 2: {(reader["attacke2"] == DBNull.Value ? "NULL" : reader["attacke2"])}, Schaden 2: {(reader["schaden_attacke2"] == DBNull.Value ? "NULL" : reader["schaden_attacke2"])}, " +
                                              $"Spezialattacke: {(reader["spezialattacke"] == DBNull.Value ? "NULL" : reader["spezialattacke"])}, Schaden Spezial: {(reader["schaden_spezialattacke"] == DBNull.Value ? "NULL" : reader["schaden_spezialattacke"])}, " +
                                              $"EXP: {reader["exp"]}, Max EXP: {reader["max_exp"]}");
                        }
                        Console.WriteLine();
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
                    Console.WriteLine($"Fehler beim Lesen der Pomekon: {ex.Message}");
                }
            }
        }

        public void InsertPoke(string name, int level, int lebenspunkte, string attacke1, int? schaden_attacke1, string attacke2, int? schaden_attacke2, string spezialattacke, int? schaden_spezialattacke, int exp, int max_exp)
        {
            string query = "INSERT INTO pokemons (name, level, lebenspunkte, attacke1, schaden_attacke1, attacke2, schaden_attacke2, spezialattacke, schaden_spezialattacke, exp, max_exp) " +
                          "VALUES (@name, @level, @lebenspunkte, @attacke1, @schaden_attacke1, @attacke2, @schaden_attacke2, @spezialattacke, @schaden_spezialattacke, @exp, @max_exp)";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@name", name),
                new MySqlParameter("@level", level),
                new MySqlParameter("@lebenspunkte", lebenspunkte),
                new MySqlParameter("@attacke1", attacke1),
                new MySqlParameter("@schaden_attacke1", schaden_attacke1),
                new MySqlParameter("@attacke2", attacke2),
                new MySqlParameter("@schaden_attacke2", schaden_attacke2),
                new MySqlParameter("@spezialattacke", spezialattacke),
                new MySqlParameter("@schaden_spezialattacke", schaden_spezialattacke),
                new MySqlParameter("@exp", exp),
                new MySqlParameter("@max_exp", max_exp)
            };
            dbConnection.ExecuteQuery(query, parameters);
        }

        public void UpdatePoke(int id, string name, int level, int lebenspunkte, string attacke1, int? schaden_attacke1, string attacke2, int? schaden_attacke2, string spezialattacke, int? schaden_spezialattacke)
        {
            string query = "UPDATE pokemons SET name = @name, level = @level, lebenspunkte = @lebenspunkte, attacke1 = @attacke1, schaden_attacke1 = @schaden_attacke1, " +
                          "attacke2 = @attacke2, schaden_attacke2 = @schaden_attacke2, spezialattacke = @spezialattacke, schaden_spezialattacke = @schaden_spezialattacke WHERE id = @id";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@id", id),
                new MySqlParameter("@name", name),
                new MySqlParameter("@level", level),
                new MySqlParameter("@lebenspunkte", lebenspunkte),
                new MySqlParameter("@attacke1", attacke1),
                new MySqlParameter("@schaden_attacke1", schaden_attacke1),
                new MySqlParameter("@attacke2", attacke2),
                new MySqlParameter("@schaden_attacke2", schaden_attacke2),
                new MySqlParameter("@spezialattacke", spezialattacke),
                new MySqlParameter("@schaden_spezialattacke", schaden_spezialattacke)
            };
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddRange(parameters);
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine(rows > 0 ? "Pomekon erfolgreich aktualisiert." : "Kein Pomekon mit dieser ID gefunden.");
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
                    Console.WriteLine($"Fehler beim Aktualisieren: {ex.Message}");
                }
            }
        }

        public void DeletePoke(int id)
        {
            string query = "DELETE FROM pokemons WHERE id = @id";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@id", id)
            };
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddRange(parameters);
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine(rows > 0 ? "Pomekon erfolgreich gelöscht." : "Kein Pomekon mit dieser ID gefunden.");
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
                    Console.WriteLine($"Fehler beim Löschen: {ex.Message}");
                }
            }
        }
    }
}
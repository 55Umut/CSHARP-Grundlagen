using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Poke
{
    public class TrainerData
    {
        private readonly DataBaseConnection dbConnection;

        public TrainerData()
        {
            dbConnection = new DataBaseConnection();
        }

        public List<Trainer> GetRandomTrainers(int count)
        {
            List<Trainer> trainers = new List<Trainer>();
            string query = $"SELECT id, name, region, mission, level, experience FROM trainer ORDER BY RAND() LIMIT {count}";
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            trainers.Add(new Trainer
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                Region = reader.GetString("region"),
                                Mission = reader.GetString("mission"),
                                Level = reader.GetInt32("level"),
                                Experience = reader.GetInt32("experience")
                            });
                        }
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
                    Console.WriteLine($"Fehler beim Abrufen der Trainer: {ex.Message}");
                }
            }
            return trainers;
        }

        public void ReadTrainers()
        {
            string query = "SELECT id, name, region, mission, level, experience FROM trainer";
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n++++ Liste der Trainer ++++\n");
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"ID: {reader["id"]}, Name: {reader["name"]}, Region: {reader["region"]}, " +
                                $"Mission: {reader["mission"]}, Level: {reader["level"]}, Erfahrung: {reader["experience"]}");
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
                    Console.WriteLine($"Fehler beim Abrufen der Trainer: {ex.Message}");
                }
            }
        }

        public void InsertTrainer(string name, string region, string mission, int level, int experience)
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
            dbConnection.ExecuteQuery(query, parameters);
        }

        public void UpdateTrainer(int id, string name, string region, string mission, int level, int experience)
        {
            string query = "UPDATE trainer SET name = @name, region = @region, mission = @mission, level = @level, experience = @experience WHERE id = @id";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@id", id),
                new MySqlParameter("@name", name),
                new MySqlParameter("@region", region),
                new MySqlParameter("@mission", mission),
                new MySqlParameter("@level", level),
                new MySqlParameter("@experience", experience)
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
                        Console.WriteLine(rows > 0 ? "Trainer erfolgreich aktualisiert." : "Kein Trainer mit dieser ID gefunden.");
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
                    Console.WriteLine($"Fehler beim Aktualisieren des Trainers: {ex.Message}");
                }
            }
        }

        public void DeleteTrainer(int id)
        {
            string query = "DELETE FROM trainer WHERE id = @id";
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
                        Console.WriteLine(rows > 0 ? "Trainer erfolgreich gelöscht." : "Kein Trainer mit dieser ID gefunden.");
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
                    Console.WriteLine($"Fehler beim Löschen des Trainers: {ex.Message}");
                }
            }
        }
    }

    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Mission { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}
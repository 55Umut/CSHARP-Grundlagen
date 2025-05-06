using System;
using MySqlConnector;

namespace Online_Shop.Models
{
    public class DB_Kunden
    {
        public static string connectionString = "Server=127.0.0.1; Database=onlineshop; User=root; Password=;";
        public static MySqlConnection connection;

        public static void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection success");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadAll()
        {
            string query = "SELECT * FROM kunden;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string name = reader["name"].ToString();
                        string vorname = reader["vorname"].ToString();
                        string straße = reader["straße"].ToString();
                        string hausnummer = reader["hausnummer"].ToString();
                        string telefonnummer = reader["telefonnummer"].ToString();

                        Console.WriteLine("-----------");
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"Vorname: {vorname}");
                        Console.WriteLine($"Straße: {straße}");
                        Console.WriteLine($"Hausnummer: {hausnummer}");
                        Console.WriteLine($"Telefonnummer: {telefonnummer}");
                        Console.WriteLine("-----------\n");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Fehler bei der Verbindung zur Datenbank: {ex.Message}");
                }
            }
        }

        public static void Insert(string name, string vorname, string straße, string hausnummer, string telefonnummer)
        {
            string query = "INSERT INTO kunden (name, vorname, straße, hausnummer, telefonnummer) " +
                           "VALUES (@name, @vorname, @straße, @hausnummer, @telefonnummer);";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@vorname", vorname);
                    command.Parameters.AddWithValue("@straße", straße);
                    command.Parameters.AddWithValue("@hausnummer", hausnummer);
                    command.Parameters.AddWithValue("@telefonnummer", telefonnummer);

                    int rows = command.ExecuteNonQuery();
                    Console.WriteLine(rows > 0 ? "Kunde erfolgreich eingefügt." : "Fehler beim Einfügen.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Fehler bei der Verbindung zur Datenbank: {ex.Message}");
                }
            }
        }

        public static void Update(int id, string name, string vorname, string straße, string hausnummer, string telefonnummer)
        {
            string query = "UPDATE kunden SET name = @name, vorname = @vorname, straße = @straße, " +
                           "hausnummer = @hausnummer, telefonnummer = @telefonnummer WHERE id = @id;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@vorname", vorname);
                    command.Parameters.AddWithValue("@straße", straße);
                    command.Parameters.AddWithValue("@hausnummer", hausnummer);
                    command.Parameters.AddWithValue("@telefonnummer", telefonnummer);

                    int rows = command.ExecuteNonQuery();
                    Console.WriteLine(rows > 0 ? "Kunde erfolgreich aktualisiert." : "Kein Kunde mit dieser ID gefunden.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Fehler beim Aktualisieren: {ex.Message}");
                }
            }
        }

        public static void Delete(int id)
        {
            string query = "DELETE FROM kunden WHERE id = @id;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    int rows = command.ExecuteNonQuery();
                    Console.WriteLine(rows > 0 ? "Kunde erfolgreich gelöscht." : "Kein Kunde mit dieser ID gefunden.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Fehler beim Löschen: {ex.Message}");
                }
            }
        }
    }
}

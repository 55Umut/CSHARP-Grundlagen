using System;
using MySqlConnector;

namespace Online_Shop.Models
{
    /// <summary>
    /// Dieses Skript kümmert sich um CRUD für Tabelle Produkte
    /// </summary>
    public class DB_Produkte
    {
        // Verbindung zur Datenbank
        public static string connectionString = "Server=127.0.0.1; Database=onlineshop; User=root; Password=;";

        public static MySqlConnection connection;

        // Verbindet sich mit der Datenbank
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
            string query = "SELECT * FROM produkte;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open(); // Verbindung öffnen

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["id"].ToString();
                    string artikelnummer = reader["artikelnummer"].ToString();
                    string produktname = reader["produktname"].ToString();
                    string preis = reader["preis"].ToString();
                    string beschreibung = reader["beschreibung"].ToString();
                    string anzahl = reader["anzahl"].ToString();
            
                    Console.WriteLine($"ID: {id} | Artikelnummer: {artikelnummer} | Produktname: {produktname} | Preis: {preis} | Beschreibung: {beschreibung} | Anzahl: {anzahl}");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Fehler bei der Verbindung zur Datenbank: {ex.Message}");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Verbindung schließen
                }
            }
        }


        // Löscht ein Produkt anhand der ID
        public static void Delete(int id)
        {
            string query = "DELETE FROM produkte WHERE id=@id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Produkt erfolgreich gelöscht.\n");
            }
            else
            {
                Console.WriteLine("Fehler beim Löschen des Produkts.\n");
            }
        }
        
        public static void Insert(Produkt produkt)
        {
            string query = "INSERT INTO produkte(artikelnummer, produktname, preis, beschreibung, anzahl) "
                           + "VALUES(@artikelnummer, @produktname, @preis, @beschreibung, @anzahl);";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open(); // Verbindung öffnen

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@artikelnummer", produkt.Artikelnummer);
                command.Parameters.AddWithValue("@produktname", produkt.Produktname);
                command.Parameters.AddWithValue("@preis", produkt.Preis);
                command.Parameters.AddWithValue("@beschreibung", produkt.Beschreibung);
                command.Parameters.AddWithValue("@anzahl", produkt.Anzahl);

                int rowsAffected = command.ExecuteNonQuery(); // Führt die SQL-Anweisung aus
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Datensatz wurde erfolgreich eingefügt!\n");
                }
                else
                {
                    Console.WriteLine("Fehler beim Einfügen des Produkts.\n");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Fehler bei der Verbindung zur Datenbank: {ex.Message}");
            }
            finally
            {
                // Schließt die Verbindung, wenn sie geöffnet wurde
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Verbindung geschlossen.");
                }
            }
        }


        // Aktualisiert ein Produkt in der Datenbank
        public static void Update(int id, Produkt produkt)
        {
            string query = "UPDATE produkte SET " +
                           "artikelnummer = @artikelnummer, " +
                           "produktname = @produktname, " +
                           "preis = @preis, " +
                           "beschreibung = @beschreibung, " +
                           "anzahl = @anzahl " +
                           "WHERE id = @id;";

            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@artikelnummer", produkt.Artikelnummer);
                command.Parameters.AddWithValue("@produktname", produkt.Produktname);
                command.Parameters.AddWithValue("@preis", produkt.Preis);
                command.Parameters.AddWithValue("@beschreibung", produkt.Beschreibung);
                command.Parameters.AddWithValue("@anzahl", produkt.Anzahl);
                int rowsAffected = command.ExecuteNonQuery();

                // Erfolg oder Fehler ausgeben
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produkt erfolgreich aktualisiert.\n");
                }
                else
                {
                    Console.WriteLine("Kein Produkt mit dieser ID gefunden.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Produkts: {ex.Message}");
            }
            
        }
        public static Produkt GetProduktByID(int id)
        {
            string query = "SELECT * FROM produkt WHERE id="+ id +";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            
            Produkt produkt = null;
            while (reader.Read())
            {
                int id2 = reader.GetInt32("id");
                int artikelnummer = reader.GetInt32("artikelnummer");
                string produktname = reader["produktname"].ToString();
                int preis = reader.GetInt32("preis");
                string beschreibung = reader["beschreibung"].ToString();
                int anzahl = reader.GetInt32("anzahl");
                
                produkt = new Produkt(id2,artikelnummer, produktname, preis, beschreibung, anzahl);
                Console.WriteLine($"ID: {id2} | Artikelnummer: {artikelnummer} | Produktname: {produktname} | Preis: {preis} | Beschreibung: {beschreibung} | Anzahl: {anzahl}");
                
            } 
            return produkt;
        }
    }
}

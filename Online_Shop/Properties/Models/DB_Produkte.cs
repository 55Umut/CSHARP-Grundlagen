using System;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Xml.Serialization.Configuration;
using MySqlConnector;

namespace Online_Shop.Properties.Models
{
    /// <summary>
    /// Dieses Skript kümmert sich um CRUD für Tabelle Produkte
    /// </summary>
    public class DB_Produkte
    {
        // enthält die daten für serveradresse. databankname. user, passwort
        public static string connectionString = "Server=127.0.0.1; Database=onlineshop; User=root;Password=;";

        public static MySqlConnection connection;

        public static void Connect()
        {
            try
            {
                // versuch diesen code auszuführen 
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection success");
            }
            catch (MySqlException e)
            {
                // wenn der try nicht klappt wird dieser block ausgeführt


                Console.WriteLine(e);
            }
        }

        public static void ReadAll()
        {
            // MySqlCommand Klasse um sql befehl an eine connection zu schicken
            string query = "SELECT * FROM produkte;";

            MySqlCommand command = new MySqlCommand(query, connection);

            // Führt den Command aus und speichert das Resultat

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //  Auf die aktuellen Spalten in der Zeile zugreifen
                string id = reader["id"].ToString();
                string artikelnummer = reader["artikelnummer"].ToString();
                string produktname = reader["produktname"].ToString();
                string preis = reader["preis"].ToString();
                string beschreibung = reader["beschreibung"].ToString();
                string anzahl = reader["anzahl"].ToString();
                
                Console.WriteLine("-----\n");
                Console.WriteLine($"ID: {id} \n" 
                                  + $"Artikelnummer: {artikelnummer} \n" 
                                  + $"Produktname: {produktname} \n" 
                                  + $"Preis: {preis}  \n" 
                                  + $"Beschreibung: {beschreibung} \n" 
                                  + $"Anzahl: {anzahl} \n");
                Console.WriteLine("--------\n");
            }
        }

        public static void Delete(int id)
        {
            
            string query = "DELETE FROM produkte WHERE id=" + id + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine($"{id} wurde gelöscht! \n");
        }

        public static void Insert()
        {
            string query = "INSERT INTO produkte ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteReader();

        }
        public static void Update()
        { 
            string query = "UPDATE produkte SET";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteReader();
             
        }
    }
}
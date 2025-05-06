using MySqlConnector;
using System;

namespace Online_Shop.Models
{
    public class DB_Benutzer
    {
        private static string connectionString = "Server=127.0.0.1; Database=onlineshop; User=root; Password=;";
        private static MySqlConnection connection;
        
        public static void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Verbindung zur Datenbank erfolgreich!");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Datenbankverbindung fehlgeschlagen: {e.Message}");
            }
        }

        // Benutzer registrieren (Neuen Benutzer in die Datenbank einfügen)
        public static bool Register(string benutzername, string passwort, string email)
        {
            try
            {
                // Sicherstellen, dass der Benutzername und die E-Mail-Adresse noch nicht existieren
                if (CheckIfUserExists(benutzername, email))
                {
                    Console.WriteLine("Benutzername oder E-Mail bereits vergeben!");
                    return false;
                }

                // Passwort verschlüsseln (z.B. mit bcrypt)
                string hashedPasswort = BCrypt.Net.BCrypt.HashPassword(passwort);

                string query = "INSERT INTO login (benutzername, passwort, email) VALUES (@benutzername, @passwort, @email)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@benutzername", benutzername);
                    command.Parameters.AddWithValue("@passwort", hashedPasswort);
                    command.Parameters.AddWithValue("@email", email);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Fehler bei der Registrierung: {ex.Message}");
                return false;
            }
        }

        // Überprüfen, ob Benutzername oder E-Mail bereits vorhanden sind
        private static bool CheckIfUserExists(string benutzername, string email)
        {
            string query = "SELECT COUNT(*) FROM login WHERE benutzername = @benutzername OR email = @email";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@benutzername", benutzername);
                command.Parameters.AddWithValue("@email", email);

                int userCount = Convert.ToInt32(command.ExecuteScalar());
                return userCount > 0;
            }
        }

        // Benutzer-Login 
        public static bool Login(string benutzername, string passwort)
        {
            try
            {
                string query = "SELECT passwort FROM login WHERE benutzername = @benutzername";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@benutzername", benutzername);

                    // Passwort aus der Datenbank abrufen
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string gespeichertesPasswort = result.ToString();

                        // Überprüfen, ob das eingegebene Passwort mit dem gespeicherten Hash übereinstimmt
                        return BCrypt.Net.BCrypt.Verify(passwort, gespeichertesPasswort);
                    }
                    return false; // Benutzername existiert nicht
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Fehler beim Login: {ex.Message}");
                return false;
            }
        }
    }
}

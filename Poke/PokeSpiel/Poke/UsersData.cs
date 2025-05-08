using MySql.Data.MySqlClient;
using System;
using BCrypt.Net;

namespace Poke
{
    public class UsersData
    {
        private readonly DataBaseConnection dbConnection;

        public UsersData()
        {
            dbConnection = new DataBaseConnection();
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT password FROM users WHERE username = @Username";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                string storedPasswordHash = reader.GetString("password");
                                return BCrypt.Net.BCrypt.Verify(password, storedPasswordHash);
                            }
                        }
                    }
                }
                return false;
            }
            catch (MySqlException ex) when (ex.Number == 1045)
            {
                throw new Exception("Datenbankzugriff verweigert: Überprüfen Sie Benutzername und Passwort.", ex);
            }
            catch (MySqlException ex) when (ex.Number == 1049)
            {
                throw new Exception("Datenbank 'pokedex' nicht gefunden.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei der Benutzerüberprüfung.", ex);
            }
        }

        public bool RegisterUser(string username, string password, string email)
        {
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @Username";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            return false;
                        }
                    }

                    string query = "INSERT INTO users (username, password, email, created_at, last_login) VALUES (@Username, @Password, @Email, NOW(), NOW())";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));
                        cmd.Parameters.AddWithValue("@Email", email);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1045)
            {
                throw new Exception("Datenbankzugriff verweigert: Überprüfen Sie Benutzername und Passwort.", ex);
            }
            catch (MySqlException ex) when (ex.Number == 1049)
            {
                throw new Exception("Datenbank 'pokedex' nicht gefunden.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei der Benutzerregistrierung.", ex);
            }
        }

        public void UpdateLastLogin(string username)
        {
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE users SET last_login = NOW() WHERE username = @Username";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1045)
            {
                throw new Exception("Datenbankzugriff verweigert: Überprüfen Sie Benutzername und Passwort.", ex);
            }
            catch (MySqlException ex) when (ex.Number == 1049)
            {
                throw new Exception("Datenbank 'pokedex' nicht gefunden.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei der Aktualisierung des letzten Logins.", ex);
            }
        }

        public bool CheckUsernameExistence(string username)
        {
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @Username";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1045)
            {
                throw new Exception("Datenbankzugriff verweigert: Überprüfen Sie Benutzername und Passwort.", ex);
            }
            catch (MySqlException ex) when (ex.Number == 1049)
            {
                throw new Exception("Datenbank 'pokedex' nicht gefunden.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei der Benutzername-Überprüfung.", ex);
            }
        }
    }
}
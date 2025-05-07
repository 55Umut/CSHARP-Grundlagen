using System;
using Online_Shop.Models;

namespace Online_Shop.Views
{
    public class Login
    {
        public static void LoginMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Login Menü ===");
                Console.WriteLine("1 Anmelden");
                Console.WriteLine("2 Registrieren");
                Console.WriteLine("3 Zurück zum Hauptmenü");

                Console.Write("Bitte wählen: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        BenutzerLogin();
                        break;
                    case "2":
                        BenutzerRegistrieren();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }

                Console.WriteLine("Zum Fortfahren eine Taste drücken...");
                Console.ReadKey();
            }
        }

        private static void BenutzerLogin()
        {
            Console.Write("Benutzername: ");
            string benutzername = Console.ReadLine();

            Console.Write("Passwort: ");
            string passwort = Console.ReadLine();

            if (DB_Benutzer.Login(benutzername, passwort))
            {
                Console.WriteLine("Login erfolgreich!");
                // Hier könntest du Benutzer-spezifisches Menü starten
            }
            else
            {
                Console.WriteLine("Login fehlgeschlagen! Überprüfe Benutzername oder Passwort.");
            }
        }

        private static void BenutzerRegistrieren()
        {
            Console.Write("Neuer Benutzername: ");
            string benutzername = Console.ReadLine();

            Console.Write("E-Mail: ");
            string email = Console.ReadLine();

            Console.Write("Passwort: ");
            string passwort = Console.ReadLine();

            bool success = DB_Benutzer.Register(benutzername, passwort, email);

            if (success)
            {
                Console.WriteLine("Registrierung erfolgreich!");
            }
            else
            {
                Console.WriteLine("Registrierung fehlgeschlagen!");
            }
        }
    }
}

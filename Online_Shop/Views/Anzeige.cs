using System;
using Online_Shop.Models;

namespace Online_Shop.Views
{
    public class Anzeige
    {
        public static int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                    return result;
                Console.WriteLine("Ungültige Eingabe, bitte geben Sie eine gültige Zahl ein.");
            }
        }

        public static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static void ProdukteInsert()
        {
            int inputArtikelnr = GetIntInput("Artikelnummer:");
            string inputProduktName = GetStringInput("Produktname:");
            int inputPreis = GetIntInput("Preis:");
            string inputBeschreibung = GetStringInput("Beschreibung:");
            int inputAnzahl = GetIntInput("Anzahl:");

            Produkt tempProdukt = new Produkt(inputArtikelnr, inputProduktName, inputPreis, inputBeschreibung, inputAnzahl);
            DB_Produkte.Insert(tempProdukt);
        }

        public static void ProdukteUpdate()
        {
            int id = GetIntInput("Produkt-ID:");
            int artikelnr = GetIntInput("Neue Artikelnummer:");
            string name = GetStringInput("Neuer Produktname:");
            int preis = GetIntInput("Neuer Preis:");
            string beschreibung = GetStringInput("Neue Beschreibung:");
            int anzahl = GetIntInput("Neue Anzahl:");

            Produkt updated = new Produkt(artikelnr, name, preis, beschreibung, anzahl);
            DB_Produkte.Update(id, updated);
        }

        public static void ProdukteMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Produkte Menü ---");
                Console.WriteLine("1 Alle Produkte anzeigen");
                Console.WriteLine("2 Produkt hinzufügen");
                Console.WriteLine("3 Produkt bearbeiten");
                Console.WriteLine("4 Produkt löschen");
                Console.WriteLine("5 Zurück");

                int input = GetIntInput("Option:");

                switch (input)
                {
                    case 1:
                        DB_Produkte.ReadAll();
                        break;
                    case 2:
                        ProdukteInsert();
                        break;
                    case 3:
                        ProdukteUpdate();
                        break;
                    case 4:
                        int deleteID = GetIntInput("Produkt-ID zum Löschen:");
                        DB_Produkte.Delete(deleteID);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Ungültige Option!");
                        break;
                }

                if (GetStringInput("Weitere Aktionen? (j/n)").ToLower() != "j")
                    break;
            }
        }

        public static void KundenMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Kunden Menü ---");
                Console.WriteLine("1 Alle Kunden anzeigen");
                Console.WriteLine("2 Kunde hinzufügen");
                Console.WriteLine("3 Kunde bearbeiten");
                Console.WriteLine("4 Kunde löschen");
                Console.WriteLine("5 Zurück");

                int input = GetIntInput("Option:");

                switch (input)
                {
                    case 1:
                        DB_Kunden.ReadAll();
                        break;
                    case 2:
                        string name = GetStringInput("Name:");
                        string vorname = GetStringInput("Vorname:");
                        string straße = GetStringInput("Straße:");
                        string hausnummer = GetStringInput("Hausnummer:");
                        string telefon = GetStringInput("Telefonnummer:");
                        DB_Kunden.Insert(name, vorname, straße, hausnummer, telefon);
                        break;
                    case 3:
                        int id = GetIntInput("Kunden-ID:");
                        name = GetStringInput("Neuer Name:");
                        vorname = GetStringInput("Neuer Vorname:");
                        straße = GetStringInput("Neue Straße:");
                        hausnummer = GetStringInput("Neue Hausnummer:");
                        telefon = GetStringInput("Neue Telefonnummer:");
                        DB_Kunden.Update(id, name, vorname, straße, hausnummer, telefon);
                        break;
                    case 4:
                        int deleteId = GetIntInput("Kunden-ID zum Löschen:");
                        DB_Kunden.Delete(deleteId);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Ungültige Option!");
                        break;
                }

                if (GetStringInput("Weitere Aktionen? (j/n)").ToLower() != "j")
                    break;
            }
        }

        public static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Hauptmenü ===");
                Console.WriteLine("1 Produkte");
                Console.WriteLine("2 Kunden");
                Console.WriteLine("3 Beenden");

                int input = GetIntInput("Bitte wählen:");

                switch (input)
                {
                    case 1:
                        ProdukteMenu();
                        break;
                    case 2:
                        KundenMenu();
                        break;
                    case 3:
                        Console.WriteLine("Programm wird beendet.");
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }

                if (GetStringInput("Zurück zum Hauptmenü? (j/n)").ToLower() != "j")
                    break;
            }
        }
        
        public static string AktuellerBenutzer { get; private set; } = "";

        public static void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Login-Menü ===");
                Console.WriteLine("1 Anmelden");
                Console.WriteLine("2 Registrieren");
                Console.WriteLine("3 Beenden");

                int input = GetIntInput("Bitte wählen:");

                switch (input)
                {
                    case 1:
                        string benutzername = GetStringInput("Benutzername:");
                        string passwort = GetStringInput("Passwort:");

                        if (DB_Benutzer.Login(benutzername, passwort))
                        {
                            AktuellerBenutzer = benutzername;
                            Console.WriteLine($"\n✅ Login erfolgreich! Willkommen, {AktuellerBenutzer}");
                            return; // zurück zum Hauptprogramm
                        }
                        else
                        {
                            Console.WriteLine("❌ Login fehlgeschlagen. Bitte erneut versuchen.");
                        }
                        break;

                    case 2:
                        string neuerBenutzer = GetStringInput("Benutzername:");
                        string email = GetStringInput("E-Mail:");
                        string neuesPasswort = GetStringInput("Passwort:");

                        if (DB_Benutzer.Register(neuerBenutzer, neuesPasswort, email))
                        {
                            Console.WriteLine("✅ Registrierung erfolgreich! Sie können sich nun einloggen.");
                        }
                        else
                        {
                            Console.WriteLine("❌ Benutzername oder E-Mail bereits vergeben.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Programm wird beendet.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }
            }
        }

    }
}

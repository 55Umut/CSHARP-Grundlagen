using System;

namespace Poke
{
    public class Anzeige
    {
        public void DisplayLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("++++ Willkommen bei Pomekon ! ++++\n");
            Console.WriteLine("1. Anmelden");
            Console.WriteLine("");
            Console.WriteLine("2. Registrieren");
            Console.Write("\nBitte wählen: ");
        }

        public void DisplayLoginSuccess()
        {
            Console.WriteLine("Erfolgreich angemeldet!");
        }

        public void DisplayLoginError()
        {
            Console.WriteLine("Fehlerhafte Anmeldedaten.");
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("++++ Verwaltungssystem ++++\n");
            Console.WriteLine("1. Trainer verwalten");
            Console.WriteLine("2. Pomekon verwalten");
            Console.WriteLine("3. Abmelden");
            Console.WriteLine("4. Beenden");
            Console.WriteLine("5. Neues Spiel");
            Console.Write("\nBitte wählen Sie eine Option (1-5): ");
        }

        public void DisplayTrainerMenu()
        {
            Console.Clear();
            Console.WriteLine("++++ Trainer verwalten ++++\n");
            Console.WriteLine("1. Trainer anzeigen");
            Console.WriteLine("2. Trainer hinzufügen");
            Console.WriteLine("3. Trainer aktualisieren");
            Console.WriteLine("4. Trainer löschen");
            Console.WriteLine("5. Zurück zum Hauptmenü");
            Console.Write("\nBitte wählen Sie eine Option (1-5): ");
        }

        public void DisplayPokemonMenu()
        {
            Console.Clear();
            Console.WriteLine("++++ Pomekon verwalten ++++\n");
            Console.WriteLine("1. Pomekon anzeigen");
            Console.WriteLine("2. Pomekon hinzufügen");
            Console.WriteLine("3. Pomekon aktualisieren");
            Console.WriteLine("4. Pomekon löschen");
            Console.WriteLine("5. Zurück zum Hauptmenü");
            Console.Write("\nBitte wählen Sie eine Option (1-5): ");
        }

        public void DisplayLogoutMessage()
        {
            Console.WriteLine("Erfolgreich abgemeldet!");
        }

        public void DisplayExitMessage()
        {
            Console.WriteLine("Beenden... Bis zum nächsten Mal!");
        }

        public void DisplayInvalidChoice()
        {
            Console.WriteLine("Ungültige Auswahl. Bitte wählen Sie eine Option zwischen 1 und 5.");
        }
    }
}
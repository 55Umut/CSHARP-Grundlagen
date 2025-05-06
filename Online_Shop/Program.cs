using Online_Shop.Models;
using Online_Shop.Views;

namespace Online_Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DB_Produkte.Connect();
            DB_Kunden.Connect();
            DB_Benutzer.Connect();

            // Login zuerst
            Anzeige.LoginMenu();

            // Wenn Login erfolgreich → ins Hauptmenü
            Anzeige.MainMenu();
        }
    }
}
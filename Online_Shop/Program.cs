using Online_Shop.Properties.Models;
using Online_Shop.Properties.Views;

namespace Online_Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DB_Produkte.Connect();
            //DB_Produkte.ReadAll();
            
            Anzeige.MainMenu();
            
        }
    }
    
}
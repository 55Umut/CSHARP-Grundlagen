using System;
using Online_Shop.Properties.Models;

namespace Online_Shop.Properties.Views
{
    public class Anzeige
    {
        public static void MainMenu()
        {
           
            Console.WriteLine($"\nWillkommen bei Hauptmenu\n");
            Console.WriteLine($"\nBitte Wählen Sie \n");
            Console.WriteLine($"1 Produkte Menu");
            Console.WriteLine($"2 Einstellungen");
            Console.WriteLine($"3 Beenden");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ProdukteMenu();
                    break;
                case 2:
                    
                    break; 
                case 3:
                    
                    break;
            }
        }

        public static void ProdukteMenu()
        {
            Console.WriteLine($"\nWillkommen zum Produkte Menu!\n");
            Console.WriteLine($"\nBitte Wählen Sie \n");
            Console.WriteLine($"1 Read All Produkte");
            Console.WriteLine($"2 Insert ");
            Console.WriteLine($"3 Update ");
            Console.WriteLine($"4 Delete ");
            int input = Convert.ToInt32(Console.ReadLine());
            
            switch (input)
            {
                case 1:
                    DB_Produkte.ReadAll();
                    break;
                case 2:
                    // INSERT
                    Console.WriteLine("Bitte geben Sie die Produkt ID ein : \n");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Bitte geben Sie die Artikelnummer ein : \n");
                    DB_Produkte.Update(input);
                    break; 
                case 3:
                    // UPDATE
                    break;
                case 4:
                    Console.WriteLine("Bitte geben Sie die Produkt ID ein : \n");
                    input = Convert.ToInt32(Console.ReadLine());
                    DB_Produkte.Delete(input);

                    
                    break;
            }
        }
        }
    
    }

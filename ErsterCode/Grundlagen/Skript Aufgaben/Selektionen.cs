using System;

namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    public class Selektionen
    {
        public static void Selektionen_inhalt()
        {
            // syntax für if(bedingung) {anweisung}
            int a = 10;
            int b = 15;
            if (a < 15)
            {
                Console.WriteLine("a ist kleiner als 15");
            }
            else
            {
                Console.WriteLine("a ist größer als 15");
            }

            if (a != b)
            {
                Console.WriteLine("a ist ungleich b");
                Console.WriteLine("");
            }
        }
    }
}
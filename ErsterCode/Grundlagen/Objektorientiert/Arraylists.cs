using System;

namespace ErsterCode.Grundlagen.Objektorientiert
{
    public class Arraylists
    {
        public static void run3()
        {
            Console.WriteLine("Bitte geben Sie eine Zahl ein : \n");
            int groesse =Convert.ToInt32(Console.ReadLine());
            
            int[] werte = new int[groesse];
            werte[0] = 0;
            werte[1] = 1;
            werte[2] = 2;
            werte[3] = 3;
            
            
        }
    }
}
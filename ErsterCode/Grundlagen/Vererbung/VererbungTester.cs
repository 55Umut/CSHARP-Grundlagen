using System;
using ErsterCode.Grundlagen.Aufgabe_Kunden;

namespace ErsterCode.Grundlagen.Vererbung
{
    public class VererbungTester
    {
        public static void run()
        {
            Humanoid[] spieler = new Humanoid[3];
            spieler[0] = new Krieger();
            spieler[1] = new Magier();
            spieler[2] = new Jaeger();
            Random runde = new Random(); 
            while (true)
            {
                foreach (Humanoid s in spieler)
                {
                    if (s.lebenspunkte > 0) 
                    {
                        Humanoid gegner;
                        do
                        {
                            gegner = spieler[runde.Next(spieler.Length)];
                        } while
                            (gegner == s ||
                             gegner.lebenspunkte <= 0); 
                        s.Angriff(gegner);
                    }
                }
                int lebendeSpieler = 0;
                foreach (Humanoid s in spieler)
                {
                    if (s.lebenspunkte > 0)
                    {
                        lebendeSpieler++;
                    }
                }
                if (lebendeSpieler <= 1)
                {
                    break;
                }
            }
            foreach (Humanoid s in spieler)
            {
                if (s.lebenspunkte > 0)
                {
                    Console.WriteLine($"{s.GetType().Name} hat überlebt!");
                }
                else
                {
                    Console.WriteLine($"{s.GetType().Name} ist gestorben.");
                }
            }
        }
    }
}
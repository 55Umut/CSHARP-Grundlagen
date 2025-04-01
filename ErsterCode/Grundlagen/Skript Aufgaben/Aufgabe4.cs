using System;

namespace ErsterCode.Grundlagen.Skript_Aufgaben
{
    public class Aufgabe4
    {
        public static void Inhalt_Aufgabe4()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string Frage4_1 = "AUFGABE 4_1: Berechnungen mit a = 10, b = 20 und x\n" +
                              "Berechnen Sie die folgenden Ausdrücke:\n" +
                              "1. x = 3 * (a + b) + b / 8\n" +
                              "2. x = (a++) + (++b)\n" +
                              "3. x = (a % b) % (b % (++a))\n";
            Console.WriteLine(Frage4_1);
            
            // Setze Anfangswerte für a und b
            int a = 10;
            int b = 20;
            int x;

            x = 3 * (a + b) + b / 8; // Berechnung
            string Antwort4_1 = $"1. x = 3 * ({a} + {b}) + {b} / 8 = {x}\n";

            // Zurücksetzen der Werte für a und b
            a = 10;
            b = 20;
            x = (a++) + (++b);
            Antwort4_1 += $"2. x = ({a++}) + ({++b}) = {x}\n"; 
            
            a = 10;
            b = 20;

            x = (a % b) % (b % (++a));
            Antwort4_1 += $"3. x = ({a} % {b}) % ({b} % (++{a})) = {x}\n";
            
            Console.WriteLine(Antwort4_1);
        }
    }
}
using System;

namespace ErsterCode.Grundlagen
{
    public class Operatoren
    {
        public static void Run()
        {
            // lokale variable
            // Arithmetrische Operatoren
            int wert1 = 10;
            int wert2 = 20;
            int summe = 0;
            int produkt = 0;

            summe = wert1 + wert2;
            produkt = wert1 * wert2;

            float x;
            x = 1.5f;
            float y;
            y = 2.5f;
            // Die einzelne und ständige einzel zuweisung ist nicht schnell 
            float quotient = x / y;
            int wert3 = 10;
            int wert4 = 8;
            int ergebnis = 0;
            ergebnis = wert3 % wert4;

            string verkettung;
            verkettung = "";
            verkettung = "Hallo" + "Welt";
        }
    }
}
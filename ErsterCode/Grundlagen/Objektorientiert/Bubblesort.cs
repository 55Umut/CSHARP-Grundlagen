using System;

namespace ErsterCode.Grundlagen.Objektorientiert
{
    public class Bubblesort
    {
        public static void run2()
        {
            int[] werte = new[] { 10, 55, 23, 18, 5, 99, 22, 33, 1, 38 };

            // array sortieren

            int hilfs;
            int i, j;
            // zwei schleifen 

            for (i = werte.Length - 2; i >= 0; i--)
            {
                for (j = 0; j <= i; j++)
                {
                    if (werte[j] > werte[j + 1])
                    {
                        // Dreieckstausch
                        hilfs = werte[j];
                        werte[j] = werte[j + 1];
                        werte[j + 1] = hilfs;
                    }
                }
            }

            for (int k = 0; k < werte.Length; k++)
            {
                Console.WriteLine(werte[k]);
            }
        }
    }
}
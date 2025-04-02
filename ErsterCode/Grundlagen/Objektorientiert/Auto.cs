using System;

namespace ErsterCode.Grundlagen.Objektorientiert
{
    public class Auto
    {
        public string hersteller;
        public string modell;
        public float kilometer;
        public string farbe;
        public int aktuelleGeschwindigkeit;

        public Auto(string hersteller, string modell, float kilometer, string farbe)
        {
            // this lernen 
            this.hersteller = hersteller;
            this.modell = modell;
            this.kilometer = kilometer;
            this.farbe = farbe;
            this.aktuelleGeschwindigkeit = 0;
        }

        public void Fahren()
        {
            aktuelleGeschwindigkeit += 30;
            Console.WriteLine($"{modell} fährt {aktuelleGeschwindigkeit} kmh ");
        }

        public void Bremsen()
        {
            while (aktuelleGeschwindigkeit >= 0)
            {
                aktuelleGeschwindigkeit -= 1;
                Console.WriteLine($"{modell} fährt {aktuelleGeschwindigkeit} kmh ");

                if (aktuelleGeschwindigkeit == 0)
                {
                    Console.WriteLine($"{modell} ist zum stehen gekommen. ");
                    break;
                }
            }
        }
    }
}
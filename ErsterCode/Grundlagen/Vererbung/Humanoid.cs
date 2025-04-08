using System;

namespace ErsterCode.Grundlagen.Vererbung
{
    public class Humanoid
    {
        public int lebenspunkte = 100;
        public int angriffsschaden = 0;

        public virtual void MachAngriff()
        {
            Console.WriteLine("Totaler Chaos brich aus!! \n");
        }

        public virtual void Angriff(Humanoid ziel)
        {
            ziel.Schaden(angriffsschaden);
        }

        public void Schaden(int wert)
        {
            lebenspunkte -= wert;


            if (lebenspunkte <= 0)
            {
                lebenspunkte = 0;
                Console.WriteLine("Aua du pupser!");
            }

            Console.WriteLine($"Lebenspunkte = {lebenspunkte}");
        }
    }
}
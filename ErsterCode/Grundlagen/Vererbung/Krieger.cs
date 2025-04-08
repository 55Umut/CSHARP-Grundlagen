using System;

namespace ErsterCode.Grundlagen.Vererbung
{
    public class Krieger : Humanoid
    {
        public string Kattack = "Krieger angriff";

        public Krieger()
        {
            angriffsschaden = 6;
        }

        public override void MachAngriff()
        {
            Console.WriteLine(Kattack);
        }

        public override void Angriff(Humanoid ziel)
        {
            Console.WriteLine($"{Kattack} trifft das Ziel!");
            ziel.Schaden(angriffsschaden);
        }
    }
}
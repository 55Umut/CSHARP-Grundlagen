using System;

namespace ErsterCode.Grundlagen.Vererbung
{
    public class Magier : Humanoid
    {
        public string Mattack = "Magiestab";

        public Magier()
        {
            angriffsschaden = 5;
        }

        public override void MachAngriff()
        {
            Console.WriteLine(Mattack);
        }

        public override void Angriff(Humanoid ziel)
        {
            Console.WriteLine($"{Mattack} trifft das Ziel!");
            ziel.Schaden(angriffsschaden);
        }
    }
}
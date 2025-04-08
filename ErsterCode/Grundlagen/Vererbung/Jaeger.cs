using System;

namespace ErsterCode.Grundlagen.Vererbung
{
    public class Jaeger : Humanoid
    {
        public string Jattack = "Jäger Schuss";

        public Jaeger()
        {
            angriffsschaden = 10;
        }

        public override void MachAngriff()
        {
            Console.WriteLine(Jattack);
        }

        public override void Angriff(Humanoid ziel)
        {
            Console.WriteLine($"{Jattack} trifft das Ziel!");
            ziel.Schaden(angriffsschaden);
        }
    }
}
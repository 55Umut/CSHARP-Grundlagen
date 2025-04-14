using System;

namespace ErsterCode.Grundlagen.Abstrakt
{
    public class Hund : Tier
    {
        public override void MakeSound()
        {
            Console.WriteLine("WUFF");
        }
    }
}
using System;
namespace ErsterCode.Grundlagen.Abstrakt
{
    public class Kunde : Person
    {
        protected int alter = 12;
        
        public override void Ausgabe()
        {
            base.Ausgabe();
            Console.WriteLine("Alter: "+ alter);
        }
    }
}
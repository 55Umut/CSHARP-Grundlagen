using System;
namespace ErsterCode.Grundlagen.Abstrakt
{
    public class Person
    {
        protected string name;
        protected string kundennummer;
        
        public virtual void Ausgabe()
        {
            
            Console.WriteLine("Name: "+ name);
            Console.WriteLine("Kundennummer: "+ kundennummer);
        }
    }
}
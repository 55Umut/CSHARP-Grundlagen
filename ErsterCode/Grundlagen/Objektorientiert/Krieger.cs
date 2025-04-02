using System;

namespace ErsterCode.Grundlagen.Objektorientiert
{
    public class Krieger
    {
        public string name;
        public string rasse;
        public int level;
        public int lebenspunkte;

        public void FressePolieren(Krieger ziel)
        {
            Console.WriteLine(ziel.name+$" hat noch {ziel.lebenspunkte} Lebenspunkte \n ");
            ziel.lebenspunkte = -1;

            if (ziel.lebenspunkte <=0)
            {
                Console.WriteLine(ziel.name+" ist verreckt ! +++ \n ");
            }
        }
    }
}
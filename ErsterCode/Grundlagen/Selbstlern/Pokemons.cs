using System;

namespace programm
{
    public class Pokemons
    {
        private string name;
        private string atk1, atk2;
        private int atkdmg1, atkdmg2, hp;

        public Pokemons(string name, string atk1, string atk2, int atkdmg1, int atkdmg2, int hp)
        {
            this.name = name;
            this.atk1 = atk1;
            this.atk2 = atk2;

            this.atkdmg1 = atkdmg1;
            this.atkdmg2 = atkdmg2;

            this.hp = hp;
        }


        // Setter
        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAtk1(string atk1)
        {
            this.atk1 = atk1;
        }

        public void SetAtk2(string akt2)
        {
            this.atk2 = atk2;
        }

        public void SetAtkDmg1(int atkdmg1)
        {
            this.atkdmg1 = atkdmg1;
        }

        public void SetAtkDmg2(int atkdmg2)
        {
            this.atkdmg2 = atkdmg2;
        }

        public void SetHp(int hp)
        {
            this.hp = hp;
        }

        // getter

        public string GetName()
        {
            return name;
        }

        public string GetAtk1()
        {
            return atk1;
        }

        public string GetAtk2()
        {
            return atk2;
        }

        public int GetAtkDmg1()
        {
            return atkdmg1;
        }

        public int GetAtkDmg2()
        {
            return atkdmg2;
        }


        //Methoden

        public Pokemons Atk1(Pokemons ziel)
        {
            Console.WriteLine($"{name} nutzt {atk1}");
            ziel.hp = ziel.hp - atkdmg1;
            Console.WriteLine($"{ziel.name}: verliert - {atkdmg1}HP");
            Console.WriteLine("Aktuelle HP :" + ziel.hp);
            return ziel;
        }

        public Pokemons Atk2(Pokemons ziel)
        {
            Console.WriteLine($"{name} nutzt {atk2}");
            ziel.hp = ziel.hp - atkdmg2;
            Console.WriteLine($"{ziel.name}: -{atkdmg2} HP");
            Console.WriteLine("HP " + ziel.hp);
            return ziel;
        }

        public void PokemonAusgabe()
        {
            Console.WriteLine("##########################");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("HP: " + hp);
            Console.WriteLine("");
            Console.WriteLine($"Attacke: {atk1}, {atk2}");
        }

        public bool PokemonLeben(Pokemons ziel)
        {
            if (ziel.hp <=0 )
            {
                Console.WriteLine($"Pokemon {ziel.name} wurde besiegt ! \n");
                return false;
                
            }
            return true;
        }
        
        
        
        public void AtkAuswaehlen(Pokemons ziel)
        {
            Console.WriteLine("##########################");
            int i = 0;
            while (i != 1 && i != 2)
            {
                Console.WriteLine($"Attacke auswählen:");
                Console.WriteLine($"1- {atk1}\n2- {atk2}");
                i = Convert.ToInt32(Console.ReadLine());
                if (i != 1 && i != 2)
                {
                    Console.WriteLine($"Ungültige Eingabe");
                    Console.WriteLine($"Versuch es nochmal...");
                }
                else if (i == 1)
                {
                    Atk1(ziel);
                }
                else if (i == 2)
                {
                    Atk2(ziel);
                }
                
            }
        }
    }
}
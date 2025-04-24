using System;
using programm;

namespace ErsterCode.Grundlagen.Selbstlern
{
    public class Trainer 
    {
        private string name;
        public Pokemons pokemon;
        private int level;

        public Trainer(string name, Pokemons pokemon, int level)
        {
            this.name = name;
            this.pokemon = pokemon;
            this.level = level;
        }

        public string GetName()
        {
            return name;
        }
        
        public void SetName(string name)
        {
            this.name = name;
        }

        public Pokemons GetPokemon()
        {
            //pokemon = new Pokemons("Shiggy", "Aqua Knarre", "Kopfnuss", 20, 10, 100);
            return pokemon;
        }

        public void SetPokemon(Pokemons pokemon)
        {
            this.pokemon = pokemon;
        }

        public int GetLevel()
        {
            return level;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }
        
        
    }
}

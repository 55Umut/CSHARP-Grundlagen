/*
 *
 * 

using System;

namespace CharacterSystem
{
    // Base Character class
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }

        public Character(string name, int health, int level)
        {
            Name = name;
            Health = health;
            Level = level;
        }

        // Virtual method for basic attack
        public virtual void MachAngriff()
        {
            Console.WriteLine($"{Name} führt einen grundlegenden Angriff aus!");
        }
    }

    // Warrior class
    public class Krieger : Character
    {
        public int Strength { get; set; }

        public Krieger(string name, int health, int level, int strength)
            : base(name, health, level)
        {
            Strength = strength;
        }

        public override void MachAngriff()
        {
            Console.WriteLine($"{Name} führt einen mächtigen Schwertangriff aus! (Stärke: {Strength})");
        }
    }

    // Mage class
    public class Magier : Character
    {
        public int MagicPower { get; set; }

        public Magier(string name, int health, int level, int magicPower)
            : base(name, health, level)
        {
            MagicPower = magicPower;
        }

        public override void MachAngriff()
        {
            Console.WriteLine($"{Name} wirft einen mächtigen Feuerball! (Magiekraft: {MagicPower})");
        }
    }

    // Hunter class
    public class Jäger : Character
    {
        public int Agility { get; set; }

        public Jäger(string name, int health, int level, int agility)
            : base(name, health, level)
        {
            Agility = agility;
        }

        public override void MachAngriff()
        {
            Console.WriteLine($"{Name} schießt einen präzisen Pfeil! (Geschicklichkeit: {Agility})");
        }
    }

    // Example usage
    public class Program
    {
        public static void Main()
        {
            // Create instances of each character type
            Krieger warrior = new Krieger("Conan", 100, 10, 15);
            Magier mage = new Magier("Gandalf", 80, 10, 20);
            Jäger hunter = new Jäger("Legolas", 90, 10, 18);

            // Demonstrate polymorphic behavior
            Character[] characters = { warrior, mage, hunter };

            foreach (var character in characters)
            {
                character.MachAngriff();
            }
        }
    }
}
*/
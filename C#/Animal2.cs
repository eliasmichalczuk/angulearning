using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{
    class Animal2
    {//sealed class Animal2 prevents from being able to inherit
        //aula 7

        private string name;
        protected string sound;
        protected AnimalIDInfo animalinfo = new AnimalIDInfo();

        public void setAnimalInfo(int idNum, string owner)
        {
            animalinfo.IDNum = idNum;
            animalinfo.Owner = owner;
        }

        public void GetAnimalinfo()
        {
            Console.WriteLine($"{Name} has the id of {animalinfo.IDNum}" +
                $" and is owned by {animalinfo.Owner}");
        }

        public static void Main(string[] args)
        {
            Animal2 whiskers = new Animal2()
            {
                Name = "Whiskers",
                Sound = "Meow"
            };

            Dog grover = new Dog()
            {
                Name = "Grover",
                Sound = "Woof",
                Sound2 = "Grr"
            };

            grover.Sound = "Woooooooof";
            whiskers.MakeSound();
            grover.MakeSound();

            whiskers.setAnimalInfo(12345, "Sally smith");
            grover.setAnimalInfo(12346, "Carlinhos");

            whiskers.GetAnimalinfo();
            grover.GetAnimalinfo();

            Animal2.AnimalHealth getHealth = new Animal2.AnimalHealth();
            Console.WriteLine($"is my animal healthy : {getHealth.HealthyWeight(11, 46)}");


            Animal2 monkey = new Animal2()
            {
                Name = "Happy",
                Sound = "Eeee"
            };

            Animal2 spot = new Dog()
            {
                Name = "Spot",
                Sound = "woof",
                Sound2 = "Grrr"
            };
            monkey.MakeSound();
            spot.MakeSound();

            Console.ReadLine();
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");

        }

        public Animal2()
            : this("No name", "No sound") { }

        public Animal2(string name)
            : this(name, "No sound") { }

        public Animal2(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(!value.Any(char.IsDigit))
                {
                    name = "No name";
                }
                name = value;
            }
        }

        public string Sound
        {
            get { return sound; }
            set
            {
                if (value.Length > 10)
                {
                    sound = "No sound";
                }
                sound = value;
            }
        }
        //inner class
        public class AnimalHealth
        {
            public bool HealthyWeight(double height, double weight)
            {
                double calc = height / weight;
                if ((calc >= .18) && (calc <= .27))
                {
                    return true;
                }
                else return false;
            }
        }


    }
}

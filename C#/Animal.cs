using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{
    //class 6
    class Animal
    {

        private string name;
        private string sound;
        public readonly int idNum;


        public static void animal(string[] args)
        {
            Animal cat = new Animal();
            cat.SetName("Whiskers");
            cat.Sound = "Meow";

            Console.WriteLine($"The cat {cat.GetName()} says {cat.Sound}");
            Console.WriteLine(Animal.NumOfAnimals);
            Console.ReadLine();
        }

        public void MakeSound()
        {
            Console.WriteLine("{0} says {1}", name, sound);
        }
        public Animal()
        :this("No Name", "No Sound") { }

        public Animal(string name)
            : this(name, "No Sound") { }

        public Animal(string name, string sound)
        {
            SetName(name);
            Sound = sound;

            NumOfAnimals = 1;

            Random rnd = new Random();
            idNum = rnd.Next(1, 2334545);
        }

        public void SetName(string name)
        {
            if(!name.Any(char.IsDigit))
            {
                this.name = name;
            }
            else
            {
                this.name = "No name";
                Console.WriteLine("Name can't contain numbers");
            }
        }

        public string GetName()
        {
            return name;
        }

        public string Sound
        {
            get { return sound; }
            set
            {
                if(value.Length > 10)
                {
                    sound = "No sound";
                    Console.WriteLine("sound is too long");
                }
                sound = value;
            }
        }

        public string Owner { get; set; } = "No owner";

        public static int numOfAnimals = 0;
        public static int NumOfAnimals
        {
            get { return numOfAnimals; }
            set { numOfAnimals += value; }
        }
    }
}

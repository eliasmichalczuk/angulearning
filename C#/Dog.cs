using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{
    class Dog : Animal2
    {
        public string Sound2 { get; set; } = "Grrr";
        //new para nao dar override no metodo da classe primaria
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound} and {Sound2}");

        }

        public Dog(string name = "No Name",
                    string sound = "No sound",
                    string sound2 = "No sound 2")
        :base(name, sound)
        {
            Sound2 = sound2;
        }


    }
}

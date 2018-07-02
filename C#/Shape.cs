using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{//Class 9
    abstract class Shape
    {
        public string Name { get; set; }

        public virtual void GetInfo()
        {
            Console.WriteLine($"This is a {Name}");
        }

        public abstract double Area();

        public static void AulaNove(string[] args)
        {
            Shape[] shapes = { new Circle(5), new Rectangle(4, 5) };

            foreach (Shape s in shapes)
            {
                s.GetInfo();
                Console.WriteLine($"{s.Name} Area: {s.Area()}");

                Circle testCirc = s as Circle;
                if(testCirc == null)
                {
                    Console.WriteLine("this isn't a circle");
                }
                else
                {
                    Console.WriteLine("This isn't a rectangle");
                }

                
            }
            object circ1 = new Circle(4);
            Circle circ2 = (Circle)circ1;

            Console.WriteLine($"The {circ2.Name} area is {circ2.Area()}");
            Console.ReadLine();
        }
    }

    
}

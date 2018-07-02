using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{//Class 9
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double Radius)
        {
            Name = "Circle";
            this.Radius = Radius;
        }
        public override double Area()
        {
            return Math.PI * (Math.Pow(Radius, 2.0));
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a radius of {Radius}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{
    class Aula1
    {
        static void AulaUm(string[] args)
        {

            Console.WriteLine("top");
            //comment ctrl  k c, undo crtl k u

            //for (int i = 1; i < args.length; i++)
            //{
            //    console.writeline("arg {0} : {1}", i, args[i]);
            //}


            //string[] myArgs = Environment.GetCommandLineArgs();
            //Console.WriteLine(string.Join(",", myArgs));
            //endereço local executavel

            //SayHello();

            //datatypes
            DateTime awesomeDate = new DateTime(1974, 12, 21);
            Console.WriteLine("Day of week : {0}", awesomeDate.DayOfWeek);
            awesomeDate = awesomeDate.AddDays(4);
            Console.WriteLine("new date: {0}",awesomeDate.Date);


            TimeSpan lunchTime = new TimeSpan(12, 30, 0);
            lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));
            lunchTime = lunchTime.Add(new TimeSpan(1, 0, 0));
            Console.WriteLine("new time : {0}", lunchTime.ToString());


            Console.WriteLine("currency : {0:c}", 23.455);
            Console.WriteLine("currency : {0:d4}", 23);
            Console.WriteLine("3 decimals : {0:f3}", 23.4555);
            Console.WriteLine("commas : {0:n4}", 2300);

            string randString = "this is a string";
            Console.WriteLine("String lengh : {0} ", randString.Length);
            Console.WriteLine("contains is : {0} ", randString.Contains("is"));

















            Console.ReadLine();
        }

        private static void SayHello()
        {
            string name = "";
            Console.WriteLine("What's your name:");
            name = Console.ReadLine();
            Console.WriteLine("Hello {0}", name);
        }
    }
}

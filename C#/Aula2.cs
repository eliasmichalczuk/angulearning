using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharTutorial
{
    class Aula2
    {
        static void aulaDois(string[] args)
        {
            var intVal = 1234;

            Console.WriteLine($"intVal type: {intVal.GetType()}");


            int[] favNums = new int[3];
            favNums[0] = 23;
            Console.WriteLine($"fav nums 0 : {favNums[0]}");

            string[] custumers = { "Bob", "Elias", "sue" };

            var employees = new[] { "Mike", "Paul" };

            object[] randomArray = {"Paul",45,1.234};

            Console.WriteLine($"randomArray 0 : {randomArray[2].GetType()}");

            string[,] custNames = new string[2, 2] { { "Bob", "Smith" }, { "Sally", "Carlos" } };
            Console.WriteLine(custNames[1, 1]);

            int[] randNums = { 1, 2, 4, 9 };
            Array.Sort(randNums);
            Array.Reverse(randNums);

            Array.IndexOf(randNums, 1);
            PrintArray(randNums, "ForEach");

            int[] srcArray = { 1, 2, 3 };
            int[] destArray = new int[2];
            int startInd = 0;
            int length = 2;

            Array.Copy(srcArray, startInd, destArray, startInd, length);
            PrintArray(destArray, "Copy");

            int[] numArray = { 1, 11, 22 };
            Console.WriteLine(">10 : {0}", Array.Find(numArray, GT10));

            //Stringbuilder

            StringBuilder sb = new StringBuilder("random text");
            StringBuilder sb2 = new StringBuilder("important stuff",256);

            Console.WriteLine("capacity : {0}", sb.Capacity);
            

            Console.ReadLine();
        }

            public static void PrintArray(int[] intArray, string message)
            {
            foreach(int k in intArray)
                {
                Console.WriteLine($"{message} : {k}");
                }
            }

        private static bool GT10(int val)
        {
            return val > 10;
        }
    }
}

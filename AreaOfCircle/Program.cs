using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            while (!finished)
            {
                bool success = TryReadNumber(out double number);
                if (success)
                {
                    Console.WriteLine($"The area is {CalculateCircleArea(number):F4}.");
                }
                else finished = true;
            }
        }

        static double CalculateCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }
        static bool TryReadNumber(out double number)
        {
            Console.Write("Please enter a number: ");
            string sNumber = Console.ReadLine();
            return double.TryParse(sNumber, out number);
        }
    }
}

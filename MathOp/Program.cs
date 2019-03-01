using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp
{
    class Program
    {
        static void Main(string[] args)
        {
            MathOperation mathOp = MathOperation.ReadFromConsole();
            while(mathOp != null)
            {
                Console.WriteLine(mathOp);
                Console.WriteLine();
                mathOp = MathOperation.ReadFromConsole();
            }
        }
    }
}

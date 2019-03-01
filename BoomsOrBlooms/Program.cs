using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoomsOrBlooms
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Please enter Boom or bloom: ");
                string input = Console.ReadLine().ToLower();
                if (input != "boom" && input != "bloom") continue;
                CountDown(5);
                if (input == "boom")
                {
                    FlashScreen(ConsoleColor.Red, ConsoleColor.Yellow);
                }
                else
                {
                    FlashScreen(ConsoleColor.Green, ConsoleColor.Blue);
                }
            }
        }
        static void FlashScreen(ConsoleColor color1, ConsoleColor color2)
        {
            for(int i=0; i<10;++i)
            {
                Console.BackgroundColor = color1;
                Console.Clear();
                Thread.Sleep(500);
                Console.BackgroundColor = color2;
                Console.Clear();
                Thread.Sleep(500);
            }
            Console.ResetColor();
            Console.Clear();
        }

        static void CountDown(int nSeconds)
        {
            while(nSeconds > 0)
            {
                Console.WriteLine(nSeconds--);
                Thread.Sleep(1000);
            }
        }
    }
}

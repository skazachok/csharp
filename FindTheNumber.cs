using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheNumber
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            int secretNumber = rand.Next(1, 1001);
            int userGuess = 0;
            int numberOfTries = 0;
            int allowedTries = 5;

            while (true)
            {
                numberOfTries++;
                Console.Write("Guess the secret number between 1 and 1000 inclusive: ");
                int.TryParse(Console.ReadLine(), out userGuess);

                if (userGuess > secretNumber)
                {
                    Console.WriteLine($"{userGuess} is too big. Try again.");
                }
                if (userGuess < secretNumber)
                {
                    Console.WriteLine($"{userGuess} is too small. Try again.");
                }
                if (numberOfTries == allowedTries)
                {
                    Console.WriteLine($"You have no tries left. The number was: {secretNumber}.");
                    break;
                }
                if (userGuess == secretNumber)
                {
                    Console.WriteLine($"That's correct! You found the number in just {numberOfTries} tries!");
                    break;
                }
                Console.Write($"You have {allowedTries - numberOfTries} tries left.");
            }
        }
    }
}
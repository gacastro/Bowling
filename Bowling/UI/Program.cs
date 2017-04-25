using System;
using Bowling;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Welcome to the bowling calculator! ****");
            Console.WriteLine("Please enter your frame set:");
            var score = Console.ReadLine();
            Console.WriteLine();

            Game game = null;
            try
            {
                game = new Game(score);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You've entered an invalid score.");
            }

            if (game != null)
                Console.WriteLine($"Your score is {game.Score}");

            Console.WriteLine();
            Console.WriteLine("Thank you for playing this awesome game.");
            Console.WriteLine("Pres any key to terminate");
            Console.Read();
        }
    }
}

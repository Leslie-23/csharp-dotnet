using System;

namespace HospitalManagementSystem
{
    public static class MiniGame
    {
        public static void Play()
        {
            Console.WriteLine("\nWelcome to the Guessing Game!");
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            int attempts = 0;

            Console.WriteLine("Guess a number between 1 and 100:");
            while (true)
            {
                attempts++;
                int guess = int.Parse(Console.ReadLine());
                if (guess == number)
                {
                    Console.WriteLine($"Congratulations! You guessed it in {attempts} attempts.");
                    break;
                }
                else if (guess < number) Console.WriteLine("Too low! Try again.");
                else Console.WriteLine("Too high! Try again.");
            }
        }
    }
}

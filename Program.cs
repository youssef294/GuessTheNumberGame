using System;
using System.Linq;

namespace GuessTheNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask user to think of a number between 0 and 100
            Console.WriteLine("I want you to think of a number between 0 and 100. Ok? Press enter to continue.");
            Console.ReadLine();

            //Define maximum number the user can guess
            int max = 100;

            //Keep track of the number of guesses
            int guesses = 0;

            //The start guess from
            int guessMin = 0;

            //The start  guess to (half of max)
            int guessMax = max / 2;

            //While the guess isn't the same as the known maximum value
            while (guessMin != max)
            {
                // Increases the guess amount
                guesses++;

                // Ask the user if their number is between the guess range
                Console.WriteLine($"Is your number between {guessMin} and {guessMax} ");
                string response = Console.ReadLine();

                // If the user confirmed their number is within the range
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    // We know the number is between guessFrom and GuessTo
                    // So set the new maximum number
                    max = guessMax;

                    //Change the next guess range to be half of the new maximum range
                    guessMax = guessMax - (guessMax - guessMin) / 2;
                }
                // The number is greater than guessMax and less than or equal to max
                else
                {
                    // The new minimum is one above the old maximum
                    guessMin = guessMax + 1;

                    // Guess the bottom half of the new range
                    int remainingDifference = max - guessMax;

                    // Set the guess max to half way between the guessMin and GuessMax
                    // NOTE: Math.Ceiling will round up the remaining differences to 2, if the difference is 3
                    guessMax += (int)Math.Ceiling(remainingDifference / 2f);
                }


                // if we only have 2 numbers left, guess one of them
                if (guessMin + 1 == max)
                {
                    //increase guess amount (by 1)
                    guesses++;

                    // Ask the user if their number is lower number
                    Console.WriteLine($"Is your number { guessMin }?");
                    response = Console.ReadLine();

                    // If the user confirmed their number is the lower number...
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        // That means the number must be the higher of the two
                        guessMin = max;
                        break;
                    }

                }  
            }
            // Tell the user their number
            Console.WriteLine($"**Your number is { guessMin } **");

            // Let the user know how many guesses it took
            Console.WriteLine($" Guessed in { guesses } guesses. Press enter to close the window");
            Console.ReadLine();
        }
    }
}


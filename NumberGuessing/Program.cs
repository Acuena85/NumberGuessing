using System;

namespace NumberGuessing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Some variables needed
            var MaxValue = 101; //Variable to hold the max value
            var intnrToGuess = new Random().Next(MaxValue); //Start with a random number

            WriteWelcome(MaxValue); //Write the welcome text to the console

            //For debug purposes
            //Console.WriteLine($"The number became: {intnrToGuess}");

            while (true)
            {
                Console.Write("Enter command or guess: ");
                var Response = Console.ReadLine().ToLower();
                if (Response == "?") //User wants the help text
                {
                    WriteHelpText();
                }
                else if (Response == "changemax") //User wants to change the max value, thus increasing the difficulty
                {
                    MaxValue = ChangeMaxValue() + 1;
                    Console.WriteLine($"Maximum number changed to: {intnrToGuess}\nCurrent guess is unaffected!");
                }
                else if (Response == "clear")
                {
                    WriteWelcome(MaxValue);
                }
                else if (Response == "exit")
                {
                    break;
                }
                else
                {
                    //Was not a command, assume it was a guess.
                    try
                    {
                        var guess = Convert.ToInt16(Response);

                        if (guess == intnrToGuess)
                        {
                            Console.WriteLine(
                                $"Correct, I was thinking of the number: {guess}\nPlease try to find the new number I am thinking off");
                            intnrToGuess = new Random().Next(MaxValue); //Randomize a new number
                            //For debug purposes
                            //Console.WriteLine($"The number became: {intnrToGuess}");
                        }
                        else if (guess > intnrToGuess)
                        {
                            Console.WriteLine("To hige");
                        }
                        else if (guess < intnrToGuess)
                        {
                            Console.WriteLine("To low");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid command entered!");
                    }
                }
            }
        }

        /// <summary>
        /// Used to write the welcome message, after clearing the console window, also outputs the current Max Value
        /// </summary>
        /// <param name="CurrMaxVal"></param>
        private static void WriteWelcome(int CurrMaxVal)
        {
            Console.Clear();
            //Welcome the user
            Console.WriteLine(
                $"Welcome!\nIn this game you will have to guess a number\nAt start, It's currently set to 0 to {CurrMaxVal - 1}\n" +
                "You can change the max value with a command\n" +
                "For help, type: ?");
        }

        /// <summary>
        /// Allow the user to change the max value.
        /// Checks for valid data before returning
        /// </summary>
        /// <returns>A new Max value</returns>
        private static int ChangeMaxValue()
        {
            while (true)
            {
                Console.Write("Please enter a new max value: ");
                var tmpres = Console.ReadLine();
                int res;
                if (int.TryParse(tmpres, out res))
                {
                    return res;
                }
            }
        }

        /// <summary>
        /// /// Output the help text to the user
        /// </summary>
        private static void WriteHelpText()
        {
            Console.WriteLine("Valid commands are:\nclear = Clears the text and re-writes the welcome text\n" +
                              "changemax = Allows for changing the max value, only accepts number\nexit = Exits the game");
        }
    }
}
using System;

namespace NumberGuessing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Some variables the game need
            // Variable to store the max value that gets generated
            var MaxValue = 101;

            // Start with a random number and store it in intnrToGuess
            // Use MaxValue to set it's max number
            var intnrToGuess = new Random().Next(MaxValue);
            
            // Write the welcome text to the console, pass along the MaxValue
            WriteWelcome(MaxValue);
            
            // Main loop
            while (true)
            {
                // Output that we want the user to give a command or guess
                Console.Write("Enter command or guess: ");
                // Read whatever the user typed in, store it in variable Response
                var Response = Console.ReadLine().ToLower();
                // Check what command was given or if it was a guess
                if (Response == "?")
                {
                    // User wants the help text, call the WriteHelpText method
                    WriteHelpText();
                }
                // User wants to change the max value, thus increasing the difficulty
                else if (Response == "changemax") 
                {
                    // User wants to change the maximum value.
                    // It calls the ChangeMaxValue function and adds 1 to the returned value
                    MaxValue = ChangeMaxValue() + 1;
                    // Give the user confirmation that the MaxValue has been changed
                    Console.WriteLine($"Maximum number changed to: {intnrToGuess}");
                    // Inform the user that the current guess is unaffected
                    Console.WriteLine("Current guess is unaffected!");
                }
                else if (Response == "clear")
                {
                    // User wants to clear the console window.
                    // WriteWelcome clears it and re-writes the welcome text
                    WriteWelcome(MaxValue);
                }
                else if (Response == "exit")
                {
                    // User wants to quit the game
                    break;
                }
                else if (Response == "igu")
                {
                    // Output the current number to the console, used to test (or cheat :P)
                    Console.WriteLine($"The current number is: {intnrToGuess}");
                }
                else if (Response == "showmax")
                {
                    // Output the current max value to the console
                    Console.WriteLine($"The current Max value is: {MaxValue}");
                }
                else
                {
                    // Was not a command, assume it was a guess.
                    try
                    {
                        var guess = Convert.ToInt16(Response);

                        if (guess == intnrToGuess)
                        {
                            Console.WriteLine($"Correct, I was thinking of the number: {guess}");
                            Console.WriteLine("Please try to find the new number I am thinking off");
                            // Randomize a new number
                            intnrToGuess = new Random().Next(MaxValue);
                        }
                        else if (guess > intnrToGuess)
                        {
                            // The guess was to high, notify the user
                            Console.WriteLine("To high");
                        }
                        else if (guess < intnrToGuess)
                        {
                            // The guess was to low, notify the user
                            Console.WriteLine("To low");
                        }
                    }
                    catch (Exception)
                    {
                        // The user entered a invalid command
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
            // Clear the console,
            Console.Clear();
            // Welcome the user
            Console.WriteLine("Welcome!");
            Console.WriteLine("In this game you will have to guess a number");
            Console.WriteLine($"At start, It's currently set to 0 to {CurrMaxVal - 1}");
            Console.WriteLine("You can change the max value with a command");
            Console.WriteLine("For help, type: ?");
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
            Console.WriteLine("Valid commands are:");
            Console.WriteLine("clear = Clears the text and re-writes the welcome text");
            Console.WriteLine("changemax = Allows for changing the max value, only accepts number");
            Console.WriteLine("showmax = Shows what the current Maxvalue is");
            Console.WriteLine("exit = Exits the game");
        }
    }
}
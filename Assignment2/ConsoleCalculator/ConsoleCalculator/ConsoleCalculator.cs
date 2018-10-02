using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ConsoleCalculator.cs
 * Created by Brian Bos
 */

namespace BrianBosAssignment2Namespace
{
    class ConsoleCalculator
    {
        static void Main(string[] args)
        {
            bool isCharacterValid;
            bool isUserInputValid;
            string userInput;
            char[] validCharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '.', ' ' };

            Console.WriteLine($"ConsoleCalculator is now running.{Environment.NewLine}Enter \"Bye\" to quit the program.{Environment.NewLine}");

            while (true)
            {
                Console.Write("Enter an expression to evaluate: ");
                userInput = Console.ReadLine();

                if (String.Compare(userInput.ToLower(), "bye") == 0)
                {
                    break;
                }

                isUserInputValid = true;

                for (int i = 0; i < userInput.Length; i++)
                {
                    isCharacterValid = false;

                    for (int j = 0; j < validCharacters.Length; j++)
                    {
                        if (userInput[i] == validCharacters[j])
                        {
                            isCharacterValid = true;
                            break;
                        }
                    }

                    if (!isCharacterValid)
                    {
                        Console.WriteLine($"Invalid character \"{userInput[i]}\" found at position {i} of the equation string.");
                        isUserInputValid = false;
                    }
                }

                if (!isUserInputValid)
                {
                    Console.WriteLine();
                    continue;
                }

                // userInput = userInput.Replace(" ", "");

                Console.WriteLine($"Result: Over 9000!{Environment.NewLine}");
            }
        }
    }
}

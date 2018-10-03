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
    public class ConsoleCalculator
    {
        public static void Main(string[] args)
        {
            int firstOperand;
            bool isCharacterValid;
            bool isErrorThrown;
            bool isUserInputValid;
            int secondOperand;
            string userInput;
            int userInputStringPosition;
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

                userInput = userInput.Replace(" ", "");

                firstOperand = getOperand(userInput, 0, out userInputStringPosition);

                if (userInputStringPosition == -1)
                {
                    continue;
                }

                int operatorStringPosition = userInputStringPosition;
                secondOperand = getOperand(userInput, userInputStringPosition + 1, out userInputStringPosition);

                if (userInputStringPosition == -1)
                {
                    continue;
                }

                int equationResult = 0;

                if (userInputStringPosition != -1)
                {
                    checked
                    {
                        try
                        {
                            isErrorThrown = false;

                            switch (userInput[operatorStringPosition])
                            {
                                case '+':
                                    equationResult = firstOperand + secondOperand;
                                    break;

                                case '-':
                                    equationResult = firstOperand - secondOperand;
                                    break;

                                case '*':
                                    equationResult = firstOperand * secondOperand;
                                    break;

                                case '/':
                                    equationResult = firstOperand / secondOperand;
                                    break;

                                default:
                                    Console.WriteLine($"Error: Invalid operator \"{userInput[operatorStringPosition]}\" encountered");
                                    break;
                            }
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine($"Error: Division by zero{Environment.NewLine}");
                            isErrorThrown = true;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"Error: Integer overflow{Environment.NewLine}");
                            isErrorThrown = true;
                        }
                    }

                    if (!isErrorThrown)
                    {
                        Console.WriteLine($"Result: {equationResult}{Environment.NewLine}");
                    }
                }
            }
        }

        static int getOperand(string equationString, int startIndex, out int operandEndStringPosition)
        {
            int stringPosition = startIndex;
            int tempOperand = 0;

            if (stringPosition >= equationString.Length)
            {
                Console.WriteLine($"Error: stringPosition was greater than or equal to equationString.Length in method getOperand(){Environment.NewLine}");
                operandEndStringPosition = -1;
                return 0;
            }

            while (equationString[stringPosition] != '+' && equationString[stringPosition] != '-' && equationString[stringPosition] != '*' && equationString[stringPosition] != '/')
            {
                checked
                {
                    try
                    {
                        tempOperand *= 10;
                        tempOperand += Convert.ToInt32(equationString[stringPosition].ToString());
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"Error: An operand was larger than {int.MaxValue} (that is, int.MaxValue){Environment.NewLine}");
                        operandEndStringPosition = -1;
                        return 0;
                    }
                }

                stringPosition++;

                if (stringPosition >= equationString.Length)
                {
                    break;
                }
            }

            operandEndStringPosition = stringPosition;
            return tempOperand;
        }
    }
}

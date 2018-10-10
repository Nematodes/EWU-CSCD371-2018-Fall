using System;

/*
 * RockPaperScissors.cs
 * Created by Brian Bos
 */

namespace BrianBosAssignment3Namespace
{
    /*
     * With this level of program complexity and requirements, I have no good reason to not make everything static.
     * Having non-static methods would imply that it is a good idea to have multiple RockPaperScissors objects running around and doing things.
     * 
     * Everything is also public for unit testing purposes.
     */
    public class RockPaperScissors
    {
        public enum GameAction
        {
            Rock,
            Paper,
            Scissors
        };

        public static void Main()
        {
            string playerInput;

            Console.WriteLine("It is time for a game of Rock, Paper, Scissors!");

            do
            {
                int playerLifePoints = 100;
                int opponentLifePoints = 100;
                Random randomNumberGenerator = new Random();

                while (true)
                {
                    // I opted for a while loop below instead of a do-while, as a do-while would involve double-checking isPlayerInputValid (once for the console output and once for the loop).
                    while (true)
                    {
                        Console.WriteLine($"{Environment.NewLine}What will your next move be?");
                        playerInput = Console.ReadLine().ToLower();
                        bool isPlayerInputValid = ValidatePlayerActionInput(playerInput);

                        if (isPlayerInputValid)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{Environment.NewLine}Invalid input!");
                        }
                    }

                    GameAction playerAction;

                    if (String.Compare(playerInput, "rock") == 0)
                    {
                        playerAction = GameAction.Rock;
                    }
                    else if (String.Compare(playerInput, "paper") == 0)
                    {
                        playerAction = GameAction.Paper;
                    }
                    else
                    {
                        playerAction = GameAction.Scissors;
                    }

                    GameAction opponentAction = GenerateOpponentAction(randomNumberGenerator);

                    if (opponentAction == GameAction.Rock)
                    {
                        Console.Write($"{Environment.NewLine}Your opponent chose rock");
                    }
                    else if (opponentAction == GameAction.Paper)
                    {
                        Console.Write($"{Environment.NewLine}Your opponent chose paper");
                    }
                    else
                    {
                        Console.Write($"{Environment.NewLine}Your opponent chose scissors");
                    }

                    (int opponentDamageTaken, int playerDamageTaken) = CalculateDealtDamage(playerAction, opponentAction);

                    if (opponentDamageTaken != 0)
                    {
                        Console.WriteLine($".{Environment.NewLine}You dealt {opponentDamageTaken} damage to your opponent!");
                        opponentLifePoints -= opponentDamageTaken;
                    }
                    else if (playerDamageTaken != 0)
                    {
                        Console.WriteLine($", dealing {playerDamageTaken} damage to you.");
                        playerLifePoints -= playerDamageTaken;
                    }
                    else
                    {
                        Console.WriteLine($".{Environment.NewLine}The result of the match was a draw.");
                    }

                    Console.WriteLine($"{Environment.NewLine}Your remaining life points : {playerLifePoints}{Environment.NewLine}Your opponent's life points: {opponentLifePoints}{Environment.NewLine}");

                    if (playerLifePoints <= 0)
                    {
                        Console.WriteLine("You were defeated by your opponent...");
                        break;
                    }
                    else if (opponentLifePoints <= 0)
                    {
                        Console.WriteLine("You have defeated your opponent!");
                        break;
                    }
                }

                Console.Write("Would you like to play another round? (y/n) ");
                playerInput = Console.ReadLine();
            } while (String.Compare(playerInput, "y") == 0);
        }

        /*
         * Returns the amount of damage dealt either by the player or by the opponent
         * 
         * This was my best idea as to where I should make a method return a tuple.
         */
        public static (int opponentDamageTaken, int playerDamageTaken) CalculateDealtDamage(GameAction playerAction, GameAction opponentAction)
        {
            // Permutation branching is nice, especially when the branch count explodes due to a very large number of choices
            if (playerAction == GameAction.Rock)
            {
                if (opponentAction == GameAction.Rock)
                {
                    return (0, 0);
                }
                else if (opponentAction == GameAction.Paper)
                {
                    return (0, 10);
                }
                else
                {
                    return (20, 0);
                }
            }
            else if (playerAction == GameAction.Paper)
            {
                if (opponentAction == GameAction.Rock)
                {
                    return (10, 0);
                }
                else if (opponentAction == GameAction.Paper)
                {
                    return (0, 0);
                }
                else
                {
                    return (0, 15);
                }
            }
            else
            {
                if (opponentAction == GameAction.Rock)
                {
                    return (0, 20);
                }
                else if (opponentAction == GameAction.Paper)
                {
                    return (15, 0);
                }
                else
                {
                    return (0, 0);
                }
            }
        }

        public static GameAction GenerateOpponentAction(Random randomNumberGenerator)
        {
            switch (randomNumberGenerator.Next() % 3)
            {
                case 0:
                    return GameAction.Rock;
                case 1:
                    return GameAction.Paper;
                default:
                    return GameAction.Scissors;
            }
        }

        // The assignment specifications do state that valid input will always be given...but that would make the program more boring than it already is
        public static bool ValidatePlayerActionInput(String playerInput)
        {
            if (String.Compare(playerInput, "rock") == 0 || String.Compare(playerInput, "paper") == 0 || String.Compare(playerInput, "scissors") == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

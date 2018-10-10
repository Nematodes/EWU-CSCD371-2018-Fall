using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/*
 * RockPaperScissorsUnitTester.cs
 * Created by Brian Bos
 */

namespace BrianBosAssignment3Namespace
{
    [TestClass]
    public class RockPaperScissorsUnitTester
    {
        [TestMethod]
        public void TestCalculateDealtDamageRockRock()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Rock, RockPaperScissors.GameAction.Rock);
            Assert.AreEqual(opponentDamageTaken, 0);
            Assert.AreEqual(playerDamageTaken, 0);
        }

        [TestMethod]
        public void TestCalculateDealtDamageRockPaper()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Rock, RockPaperScissors.GameAction.Paper);
            Assert.AreEqual(opponentDamageTaken, 0);
            Assert.AreEqual(playerDamageTaken, 10);
        }

        [TestMethod]
        public void TestCalculateDealtDamageRockScissors()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Rock, RockPaperScissors.GameAction.Scissors);
            Assert.AreEqual(opponentDamageTaken, 20);
            Assert.AreEqual(playerDamageTaken, 0);
        }

        [TestMethod]
        public void TestCalculateDealtDamagePaperRock()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Paper, RockPaperScissors.GameAction.Rock);
            Assert.AreEqual(opponentDamageTaken, 10);
            Assert.AreEqual(playerDamageTaken, 0);
        }

        [TestMethod]
        public void TestCalculateDealtDamagePaperPaper()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Paper, RockPaperScissors.GameAction.Paper);
            Assert.AreEqual(opponentDamageTaken, 0);
            Assert.AreEqual(playerDamageTaken, 0);
        }

        [TestMethod]
        public void TestCalculateDealtDamagePaperScissors()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Paper, RockPaperScissors.GameAction.Scissors);
            Assert.AreEqual(opponentDamageTaken, 0);
            Assert.AreEqual(playerDamageTaken, 15);
        }

        [TestMethod]
        public void TestCalculateDealtDamageScissorsRock()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Scissors, RockPaperScissors.GameAction.Rock);
            Assert.AreEqual(opponentDamageTaken, 0);
            Assert.AreEqual(playerDamageTaken, 20);
        }

        [TestMethod]
        public void TestCalculateDealtDamageScissorsPaper()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Scissors, RockPaperScissors.GameAction.Paper);
            Assert.AreEqual(opponentDamageTaken, 15);
            Assert.AreEqual(playerDamageTaken, 0);
        }

        [TestMethod]
        public void TestCalculateDealtDamageScissorsScissors()
        {
            (int opponentDamageTaken, int playerDamageTaken) = RockPaperScissors.CalculateDealtDamage(RockPaperScissors.GameAction.Scissors, RockPaperScissors.GameAction.Scissors);
            Assert.AreEqual(opponentDamageTaken, 0);
            Assert.AreEqual(playerDamageTaken, 0);
        }

        [TestMethod]
        public void TestGenerateOpponentActionDistribution()
        {
            int rockCount = 0;
            int paperCount = 0;
            int scissorsCount = 0;

            for (int i = 0; i < 10000; i++)
            {
                System.Random randomNumberGenerator = new System.Random();

                switch (RockPaperScissors.GenerateOpponentAction(randomNumberGenerator))
                {
                    case RockPaperScissors.GameAction.Rock:
                        rockCount++;
                        break;
                    case RockPaperScissors.GameAction.Paper:
                        paperCount++;
                        break;
                    case RockPaperScissors.GameAction.Scissors:
                        scissorsCount++;
                        break;
                }
            }

            // The ranges here are quite large, just to make sure that it will only fail if something goes very wrong
            Assert.IsTrue(rockCount >= 2500 && rockCount <= 4166);
            Assert.IsTrue(paperCount >= 2500 && paperCount <= 4166);
            Assert.IsTrue(scissorsCount >= 2500 && scissorsCount <= 4166);
        }

        [TestMethod]
        public void TestValidateUserActionInput()
        {
            Assert.IsTrue(RockPaperScissors.ValidatePlayerActionInput("rock"));
            Assert.IsTrue(RockPaperScissors.ValidatePlayerActionInput("paper"));
            Assert.IsTrue(RockPaperScissors.ValidatePlayerActionInput("scissors"));

            Assert.IsFalse(RockPaperScissors.ValidatePlayerActionInput("Rock"));
            Assert.IsFalse(RockPaperScissors.ValidatePlayerActionInput(" rock"));
            Assert.IsFalse(RockPaperScissors.ValidatePlayerActionInput("rock paper"));
            Assert.IsFalse(RockPaperScissors.ValidatePlayerActionInput("paperscissors"));
            Assert.IsFalse(RockPaperScissors.ValidatePlayerActionInput("tangerine"));
            Assert.IsFalse(RockPaperScissors.ValidatePlayerActionInput(""));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignment2Namespace
{
    [TestClass]
    public class ArithmeticTests
    {
        [TestMethod]
        public void TestAddition()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + 2\n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<123 - 456\n>>Result: -333\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<360 * 420\n>>Result: 151200\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestDivision()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<108 / 12\n>>Result: 9\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<5 / 2\n>>Result: 2\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 / 0\n>>Error: Division by zero\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentFive
{
    [TestClass]
    public class InterfaceConsoleTests : IConsole
    {
        private string ConsoleOutputString;
        private InterfaceConsoleTests DummyInterfaceConsoleTests;

        [TestInitialize]
        public void InitializeDummyInterfaceConsoleTests()
        {
            DummyInterfaceConsoleTests = new InterfaceConsoleTests();
        }

        [TestMethod]
        public void ConsoleOutput_NormalInput_OutputIsNormal()
        {
            DummyInterfaceConsoleTests.ConsoleOutput("This is supposed to be input!\n");
            Assert.IsTrue(DummyInterfaceConsoleTests.ConsoleOutputString.Equals("This is supposed to be input!\n"));
        }

        [TestMethod]
        public void ConsoleOutput_EmptyInput_OutputIsEmpty()
        {
            DummyInterfaceConsoleTests.ConsoleOutput("");
            Assert.IsTrue(DummyInterfaceConsoleTests.ConsoleOutputString.Equals(""));
        }

        [TestMethod]
        public void ConsoleOutput_NullInput_OutputIsNull()
        {
            DummyInterfaceConsoleTests.ConsoleOutput(null);
            Assert.AreEqual(DummyInterfaceConsoleTests.ConsoleOutputString, null);
        }

        public void ConsoleOutput(string output)
        {
            ConsoleOutputString = output;
        }
    }
}
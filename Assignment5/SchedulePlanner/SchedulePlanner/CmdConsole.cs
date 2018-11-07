using System;
using System.Collections.Generic;
using System.Text;

namespace BrianBosAssignmentSix
{
    public class CmdConsole : IConsole
    {
        public string ConsoleInput()
        {
            return Console.ReadLine();
        }

        public void ConsoleOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}

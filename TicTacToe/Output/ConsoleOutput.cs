using System;

namespace TicTacToe.Output
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string template, string arg1, string arg2)
        {
            Console.WriteLine(template, arg1, arg2);
        }
    }
}
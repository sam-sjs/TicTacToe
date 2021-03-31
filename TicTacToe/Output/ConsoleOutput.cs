using System;

namespace TicTacToe
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
    }
}
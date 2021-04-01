using System;

namespace TicTacToe.Input
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleOutput output = new ConsoleOutput();
            Display message = new Display(output);
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(message, input);
            game.Play();
        }
    }
}
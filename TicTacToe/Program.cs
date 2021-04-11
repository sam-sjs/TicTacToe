
using TicTacToe.Input;
using TicTacToe.Output;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleOutput output = new ConsoleOutput();
            Display display = new Display(output);
            ConsoleInput input = new ConsoleInput();
            CoordinateProcessor processor = new CoordinateProcessor();
            Game game = new Game(display, input, processor);
            game.Play();
        }
    }
}

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
            Game.Game game = new Game.Game();
            Controller controller = new Controller(display, input, game, processor);
            controller.Play();
        }
    }
}
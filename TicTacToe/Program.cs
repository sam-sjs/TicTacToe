
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
            Board board = new Board();
            Coordinates coordinates = new Coordinates(display, input);
            Game game = new Game(display, input, board, coordinates);
            game.Play();
        }
    }
}
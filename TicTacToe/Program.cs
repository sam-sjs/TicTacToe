
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
            Board board = new Board();
            Player player1 = new Player("Player 1", Token.Cross);
            Player player2 = new Player("Player 2", Token.Naught);
            Game.TicTacToeGame ticTacToeGame = new Game.TicTacToeGame(board, player1, player2);
            Controller controller = new Controller(display, input, ticTacToeGame, processor);
            controller.Play();
        }
    }
}
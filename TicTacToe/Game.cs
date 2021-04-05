
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        public Game(Display display, IInput input, Board board, Coordinates coordinates)
        {
            Display = display;
            Input = input;
            Board = board;
            Coordinates = coordinates;
        }

        public Display Display { get; }
        public IInput Input { get; }
        public Board Board { get; }
        public Coordinates Coordinates { get; }
        public void Play()
        {
            Display.Welcome();
            Display.Board(Board);
            string coords = Coordinates.GetCoordinates();
        }
    }
}
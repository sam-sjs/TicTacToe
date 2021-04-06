
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        public Game(Display display, IInput input, Board board, CoordinateProcessor processor)
        {
            Display = display;
            Input = input;
            Board = board;
            Processor = processor;
        }

        public Display Display { get; }
        public IInput Input { get; }
        public Board Board { get; }
        public CoordinateProcessor Processor { get; }
        public void Play()
        {
            Display.Welcome();
            Display.Board(Board);
            Display.AskForCoordinates();
            Location location = GetLocation();
        }

        public Location GetLocation()
        {
            string coords;
            while (true)
            {
                coords = Input.ReadLine();
                if (Processor.ValidateCoordinates(coords)) break;
                Display.InvalidCoordinates();
            }
            
            return Processor.ConvertCoordinates(coords);
        }
    }
}
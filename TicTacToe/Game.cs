
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        private const string Player1 = "Player 1";
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
            DisplayOpeningMessages();
            TakeTurn();
        }

        public void DisplayOpeningMessages()
        {
            Display.Welcome();
            Display.Board(Board);
        }
        
        public void TakeTurn()
        {
            Display.AskForCoordinates(Player1); // Maybe player should be a class knowing its piece as have to keep it in lockstep.
            Board.PlacePiece(GetLocation(), Piece.Cross);
            Display.MoveAccepted();
            Display.Board(Board);
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
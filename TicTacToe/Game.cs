
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
            Player1 = new Player("Player 1", Token.Cross);
            Player2 = new Player("Player 2", Token.Naught);
        }

        public Display Display { get; }
        public IInput Input { get; }
        public Board Board { get; }
        public CoordinateProcessor Processor { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
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
            Display.AskForCoordinates(Player1.Name);
            Board.PlacePiece(GetLocation(), Token.Cross); // Now have pieces stored in Player
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
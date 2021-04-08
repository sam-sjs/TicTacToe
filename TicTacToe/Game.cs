
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        public Game(Display display, IInput input, CoordinateProcessor processor)
        {
            Display = display;
            Input = input;
            Board = new Board();
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
            TakeTurn(Player1);
        }

        private void DisplayOpeningMessages()
        {
            Display.Welcome();
            Display.Board(Board);
        }
        
        private void TakeTurn(Player player)
        {
            Display.AskForCoordinates(player.Name);
            Board.PlacePiece(GetLocation(), player.Token);
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
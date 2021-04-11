
using System.Linq;
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        private int _gameTurn = 0;
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
            AlternateTurns();
        }

        private void DisplayOpeningMessages()
        {
            Display.Welcome();
            Display.Board(Board);
        }

        private void AlternateTurns() // This seems insane to try and test, without testing an entire game of inputs and outputs it will just hang in the loop
        {
            while (!CheckForWin())
            {
                TakeTurn(GetCurrentPlayer());
                _gameTurn++;
            }
        }

        public bool CheckForWin()
        {
            return CheckForHorizontalWin() ||
                   CheckForVerticalWin() ||
                   CheckForDiagonalWin();
        }

        public bool CheckForHorizontalWin()
        {
            return CheckLineForWin(Board.GetTopLine()) ||
                   CheckLineForWin(Board.GetHorizontalMidLine()) ||
                   CheckLineForWin(Board.GetBottomLine());
        }

        public bool CheckLineForWin(Token[] line)
        {
            Token first = line.First();
            return line.All(token => token == first && first != Token.Empty);
        }

        public bool CheckForVerticalWin()
        {
            return CheckLineForWin(Board.GetLeftLine()) ||
                   CheckLineForWin(Board.GetVerticalMidLine()) ||
                   CheckLineForWin(Board.GetRightLine());
        }

        public bool CheckForDiagonalWin()
        {
            return CheckLineForWin(Board.GetTopLeftToBottomRightLine()) ||
                   CheckLineForWin(Board.GetTopRightToBottomLeftLine());
        }

        private void TakeTurn(Player player)
        {
            Display.AskForCoordinates(player);
            Board.PlacePiece(GetLocation(), player.Token);
            Display.MoveAccepted();
            Display.Board(Board);
        }

        public Player GetCurrentPlayer()
        {
            return _gameTurn % 2 == 0 ? Player1 : Player2;
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

using System.Linq;
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        private int _gameTurn = 0;
        private bool _playerHasQuit = false;
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

        private void AlternateTurns()
        {
            while (!CheckForGameEnd())
            {
                TakeTurn();
                _gameTurn++;
            }
        }

        public bool CheckForGameEnd()
        {
            return CheckForWin() ||
                   CheckForDraw();
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

        public bool CheckForDraw()
        {
            return Board.Cells.All(cell => cell.Token != Token.Empty);
        }

        private void TakeTurn()
        {
            Display.AskForCoordinates(GetCurrentPlayer());
            ProcessUserInput();
        }

        public void ProcessUserInput()
        {
            while (true)
            {
                string input = Input.ReadLine();
                if (input == "q")
                {
                    _playerHasQuit = true;
                    break;
                }

                if (Processor.ValidateCoordinates(input))
                {
                    MakeMove(input);
                    break;
                }
                Display.InvalidCoordinates();
            }
        }

        public void MakeMove(string input)
        {
            Board.PlacePiece(Processor.ConvertCoordinates(input), GetCurrentPlayer().Token);
            Display.MoveAccepted();
            Display.Board(Board);
        }

        public Player GetCurrentPlayer()
        {
            return _gameTurn % 2 == 0 ? Player1 : Player2;
        }
    }
}
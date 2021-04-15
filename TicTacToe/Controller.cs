using TicTacToe.Input;
using TicTacToe.Game;

namespace TicTacToe
{
    public class Controller
    {
        private const string QuitKey = "q";
        private readonly Display _display;
        private readonly IInput _input;
        private readonly TicTacToeGame _ticTacToeGame;
        private readonly CoordinateProcessor _processor;
        public Controller(Display display,  IInput input, TicTacToeGame ticTacToeGame, CoordinateProcessor processor)
        {
            _display = display;
            _input = input;
            _ticTacToeGame = ticTacToeGame;
            _processor = processor;
        }

        public void Play()
        {
            DisplayOpeningMessages();
            AlternateTurns();
            
        }

        private void DisplayOpeningMessages()
        {
            _display.Welcome();
            _display.Board(_ticTacToeGame.GetBoardDisplay());
        }

        private void AlternateTurns()
        {
            while (!_ticTacToeGame.IsGameEnded())
            {
                TakeTurn();
                _ticTacToeGame.Turn++;
            }
        }

        private void TakeTurn()
        {
            _display.AskPlayerForCoordinates(_ticTacToeGame.GetCurrentPlayer());
            ProcessUserInput();
        }

        private void ProcessUserInput()
        {
            while (true)
            {
                string input = _input.ReadLine();
                if (input == QuitKey)
                {
                    _ticTacToeGame.PlayerHasQuit = true;
                    break;
                }

                if (_processor.ValidateCoordinates(input))
                {
                    AdvanceTurn(input);
                    break;
                }
                
                _display.InvalidCoordinates();
            }
        }

        private void AdvanceTurn(string input)
        {
            _ticTacToeGame.MakeMove(_processor.ConvertCoordinates(input));
            _display.MoveAccepted();
            _display.Board(_ticTacToeGame.GetBoardDisplay());
        }
    }
}
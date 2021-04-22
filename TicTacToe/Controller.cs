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
            DisplayClosingMessage();
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
            ProcessUserInput(GetValidInput());
        }

        private string GetValidInput()
        {
            string input;
            while (true)
            {
                input = _input.ReadLine();
                if (IsInputValid(input)) break;
                _display.InvalidInput();
            }

            return input;
        }

        private bool IsInputValid(string input)
        {
            return _processor.IsCoordinateValid(input) &&
                   _ticTacToeGame.IsCellEmpty(_processor.ConvertCoordinate(input));
        }

        private void ProcessUserInput(string input)
        {
            if (input == QuitKey)
            {
                _ticTacToeGame.PlayerHasQuit = true;
            }
            AdvanceTurn(input);
        }

        private void AdvanceTurn(string input)
        {
            _ticTacToeGame.MakeMove(_processor.ConvertCoordinate(input));
            _display.MoveAccepted();
            _display.Board(_ticTacToeGame.GetBoardDisplay());
        }

        private void DisplayClosingMessage()
        {
            if (_ticTacToeGame.IsGameWon()) _display.Winner();
            if (_ticTacToeGame.IsGameADraw()) _display.GameDrawn();
        }
    }
}
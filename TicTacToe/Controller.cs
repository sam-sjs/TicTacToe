using TicTacToe.Input;

namespace TicTacToe
{
    public class Controller
    {
        private readonly Display _display;
        private readonly IInput _input;
        private readonly Game.Game _game; // Google convention
        private readonly CoordinateProcessor _processor;
        public Controller(Display display,  IInput input, Game.Game game, CoordinateProcessor processor)
        {
            _display = display;
            _input = input;
            _game = game;
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
            _display.Board(_game.GetBoardDisplay());
        }

        private void AlternateTurns()
        {
            while (!_game.IsGameEnded())
            {
                TakeTurn();
                _game.Turn++;
            }
        }

        private void TakeTurn()
        {
            _display.AskForCoordinates(_game.GetCurrentPlayer());
            ProcessUserInput();
        }

        private void ProcessUserInput()
        {
            while (true)
            {
                string input = _input.ReadLine();
                if (input == "q")
                {
                    _game.PlayerHasQuit = true;
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
            _game.MakeMove(_processor.ConvertCoordinates(input));
            _display.MoveAccepted();
            _display.Board(_game.GetBoardDisplay());
        }
    }
}
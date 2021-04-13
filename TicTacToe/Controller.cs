namespace TicTacToe
{
    public class Controller
    {
        private readonly Display _display;
        public Controller(Display display)
        {
            _display = display;
            Board = new Board();
        }

        private Board Board { get; }
        
        public void Play()
        {
            DisplayOpeningMessages();   
        }

        private void DisplayOpeningMessages()
        {
            _display.Welcome();
            // Should I create a method on Game to hide Board from Controller as Game and Board are both core business
            // logic and I want to hide as much as possible from the edge display logic?
            // Also does creating a Game.GetBoard() and moving instantiation of the Board into Game really hide it given
            // it will still return a Board object?
            // Can we also just have a little bit of a discussion on composition, at what level should I instantiate a
            // new object vs pass in from a higher level class / Program.
            _display.Board(Board);
        }
    }
}
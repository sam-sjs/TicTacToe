namespace TicTacToe
{
    public class Message
    {
        private IOutput _output;

        public Message(IOutput output)
        {
            _output = output;
        }

        public void DisplayWelcome()
        {
            _output.WriteLine("Welcome to Tic Tac Toe!");
        }
    }
}
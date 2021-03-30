namespace TicTacToe
{
    public class Message
    {
        private IOutput _output;

        public Message(IOutput output)
        {
            _output = output;
        }

        public void Welcome()
        {
            _output.WriteLine("Welcome to Tic Tac Toe!");
            _output.WriteLine();
            _output.WriteLine("Here's the current board:");
        }

        public void Board()
        {
            _output.WriteLine(". . .");
            _output.WriteLine(". . .");
            _output.WriteLine(". . .");
        }
    }
}
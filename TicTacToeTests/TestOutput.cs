using TicTacToe;

namespace TicTacToeTests
{
    public class TestOutput : IOutput
    {
        public string Message;

        public void WriteLine(string message)
        {
            Message = message;
        }
    }
}
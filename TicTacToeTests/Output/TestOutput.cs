using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestOutput : IOutput
    {
        public List<string> Messages = new List<string>();

        public void WriteLine()
        {
            Messages.Add("");
        }
        public void WriteLine(string message)
        {
            Messages.Add(message);
        }
    }
}
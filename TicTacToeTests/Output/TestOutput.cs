using System;
using System.Collections.Generic;
using TicTacToe.Output;

namespace TicTacToeTests.Output
{
    public class TestOutput : IOutput
    {
        public readonly List<string> Messages = new List<string>();

        public void WriteLine()
        {
            Messages.Add("");
        }
        public void WriteLine(string message)
        {
            Messages.Add(message);
        }

        public void WriteLine(string template, string arg1, string arg2)
        {
            Messages.Add(String.Format(template, arg1, arg2));
        }
    }
}
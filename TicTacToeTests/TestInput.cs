using System;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestInput : IInput
    {
        private readonly string _input;

        public TestInput(string input)
        {
            _input = input;
        }
        public string ReadLine()
        {
            return _input;
        }
    }
}
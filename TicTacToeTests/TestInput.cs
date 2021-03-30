using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestInput : IInput
    {
        private readonly List<string> _inputs;
        private int _timesCalled;

        public TestInput(List<string> inputs)
        {
            _inputs = inputs;
        }
        public string ReadLine()
        {
            return _inputs[_timesCalled++];
        }
    }
}
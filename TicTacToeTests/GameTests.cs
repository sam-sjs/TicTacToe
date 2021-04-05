
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void ReadLine_ShouldReturnExpectedString()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            Coordinates coordinates = new Coordinates(display, input);
            Board board = new Board();
            Game game = new Game(display, input, board, coordinates);
            string expected = "1,2"; 

            string actual = game.Input.ReadLine();

            Assert.Equal(expected, actual);
        }
    }
}

using System.Collections.Generic;
using TicTacToe;
using TicTacToe.Input;
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
            Coordinates interpreter = new Coordinates(display, input);
            Board board = new Board();
            Game game = new Game(display, input, board, interpreter);
            string expected = "1,2"; 

            string actual = game.Input.ReadLine();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertCoordinates_GivenString_ShouldReturnRespectiveEnum()
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            ConsoleInput input = new();
            Coordinates interpreter = new Coordinates(display, input);
            Board board = new Board();
            Game game = new Game(display, input, board, interpreter);
            string coordsToConvert = "1,2";
            Location expected = Location.TopMid;

            Location actual = game.ConvertCoordinates(coordsToConvert);

            Assert.Equal(expected, actual);
        }
    }
}
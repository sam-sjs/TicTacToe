
using System.Collections.Generic;
using TicTacToe;
using TicTacToeTests.Input;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void Game_ShouldHavePlayer1()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            CoordinateProcessor processor = new CoordinateProcessor();
            Board board = new Board();
            Game game = new Game(display, input, board, processor);
            string expected = "Player 1";

            string actual = game.Player1.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_ShouldHavePlayer2()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            CoordinateProcessor processor = new CoordinateProcessor();
            Board board = new Board();
            Game game = new Game(display, input, board, processor);
            string expected = "Player 2";

            string actual = game.Player2.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void Game_PlayersShouldHaveUniqueTokens()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            CoordinateProcessor processor = new CoordinateProcessor();
            Board board = new Board();
            Game game = new Game(display, input, board, processor);
            
            Assert.NotEqual(game.Player1.Token, game.Player2.Token);
        }

        [Fact]
        public void GetLocation_GivenStringCoordinates_ShouldReturnLocation()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            CoordinateProcessor processor = new CoordinateProcessor();
            Board board = new Board();
            Game game = new Game(display, input, board, processor);
            Location expected = Location.TopMid;

            Location actual = game.GetLocation();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetInputs()
        {
            yield return new object[] {new List<string> {"1,Q", "1,2"}, Location.TopMid};
            yield return new object[] {new List<string> {"Q,2", "2,3"}, Location.MidRight};
            yield return new object[] {new List<string> {"12,2", "1,1"}, Location.TopLeft};
            yield return new object[] {new List<string> {"1,8", "4,4", "1,2"}, Location.TopMid};
        }
        
        [Theory]
        [MemberData(nameof(GetInputs))]
        public void GetLocation_GivenInvalidCoordinates_AwaitValidCoordinates(List<string> inputs, Location expected)
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            CoordinateProcessor processor = new CoordinateProcessor();
            Board board = new Board();
            Game game = new Game(display, input, board, processor);

            Location actual = game.GetLocation();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReadLine_ShouldReturnExpectedString()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            CoordinateProcessor processor = new CoordinateProcessor();
            Board board = new Board();
            Game game = new Game(display, input, board, processor);
            string expected = "1,2"; 

            string actual = game.Input.ReadLine();

            Assert.Equal(expected, actual);
        }
    }
}
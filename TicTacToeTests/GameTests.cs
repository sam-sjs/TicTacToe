
using System.Collections.Generic;
using TicTacToe;
using TicTacToeTests.Input;
using TicTacToeTests.Output;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        private readonly Display _display;
        private readonly CoordinateProcessor _processor;
        public GameTests()
        {
            TestOutput output = new TestOutput();
            _display = new Display(output);
            _processor = new CoordinateProcessor();
        }

        [Fact]
        public void Game_ShouldHavePlayer1()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestInput input = new TestInput(inputs);
            Game game = new Game(_display, input, _processor);
            string expected = "Player 1";

            string actual = game.Player1.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_ShouldHavePlayer2()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestInput input = new TestInput(inputs);
            Game game = new Game(_display, input, _processor);
            string expected = "Player 2";

            string actual = game.Player2.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void Game_PlayersShouldHaveUniqueTokens()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestInput input = new TestInput(inputs);
            Game game = new Game(_display, input, _processor);
            
            Assert.NotEqual(game.Player1.Token, game.Player2.Token);
        }
        
        [Fact]
        public void GetLocation_GivenStringCoordinates_ShouldReturnLocation()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestInput input = new TestInput(inputs);
            Game game = new Game(_display, input, _processor);
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
            TestInput input = new TestInput(inputs);
            Game game = new Game(_display, input, _processor);

            Location actual = game.GetLocation();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReadLine_ShouldReturnExpectedString()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestInput input = new TestInput(inputs);
            Game game = new Game(_display, input, _processor);
            string expected = "1,2"; 

            string actual = game.Input.ReadLine();

            Assert.Equal(expected, actual);
        }

        // [Fact]
        // public void CheckHorizontalWin_WhenThreeMatchingTokensInARow_ShouldReturnTrue()
        // {
        //     List<string> inputs = new List<string> {"1,2"}; // This input is going to break a bunch of tests once we have two players
        //     TestInput input = new TestInput(inputs);
        //     Game game = new Game(_display, input, _processor);
        //     game.Board.PlacePiece(Location.TopLeft, Token.Cross);
        //     game.Board.PlacePiece(Location.TopMid, Token.Cross);
        //     game.Board.PlacePiece(Location.TopRight, Token.Cross);
        //     
        //     Assert.True(game.CheckHorizontalWin());
        // }
    }
}
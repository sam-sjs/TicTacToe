
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using TicTacToe;
using TicTacToe.Input;
using TicTacToeTests.Input;
using Xunit;
using Xunit.Sdk;
using TestOutput = TicTacToeTests.Output.TestOutput;

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
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            string expected = "Player 1";

            string actual = game.Player1.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_ShouldHavePlayer2()
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            string expected = "Player 2";

            string actual = game.Player2.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void Game_PlayersShouldHaveUniqueTokens()
        {
            ConsoleInput input = new ConsoleInput();
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

        [Theory]
        [InlineData(new[] {Token.Cross, Token.Cross, Token.Cross}, true)]
        [InlineData(new[] {Token.Cross, Token.Naught, Token.Empty}, false)]
        public void CheckLineForWin_ShouldReturnTrueOnAllMatching(Token[] testRow, bool expected)
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
        
            bool actual = game.CheckLineForWin(testRow);
        
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckLineForWin_ShouldReturnFalseOnEmpty()
        {
            Token[] testRow = {Token.Empty, Token.Empty, Token.Empty};
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            bool expected = false;
        
            bool actual = game.CheckLineForWin(testRow);
        
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Location.TopLeft, Location.TopMid, Location.TopRight, true)]
        [InlineData(Location.MidLeft, Location.Centre, Location.MidRight, true)]
        [InlineData(Location.TopLeft, Location.MidLeft, Location.BottomLeft, false)]
        public void CheckForHorizontalWin_ShouldReturnTrueOnThreeInARow(Location loc1, Location loc2, Location loc3, bool expected)
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(loc1, Token.Cross);
            game.Board.PlacePiece(loc2, Token.Cross);
            game.Board.PlacePiece(loc3, Token.Cross);

            bool actual = game.CheckForHorizontalWin();
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Location.TopLeft, Location.MidLeft, Location.BottomLeft, true)]
        [InlineData(Location.TopRight, Location.MidRight, Location.BottomRight, true)]
        [InlineData(Location.TopLeft, Location.TopMid, Location.TopRight, false)]
        public void CheckForVerticalWin_ShouldReturnTrueOnThreeInARow(Location loc1, Location loc2, Location loc3, bool expected)
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(loc1, Token.Cross);
            game.Board.PlacePiece(loc2, Token.Cross);
            game.Board.PlacePiece(loc3, Token.Cross);

            bool actual = game.CheckForVerticalWin();
            
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(Location.TopLeft, Location.Centre, Location.BottomRight, true)]
        [InlineData(Location.TopRight, Location.Centre, Location.BottomLeft, true)]
        [InlineData(Location.TopLeft, Location.TopMid, Location.TopRight, false)]
        public void CheckForDiagonalWin_ShouldReturnTrueOnThreeInARow(Location loc1, Location loc2, Location loc3, bool expected)
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(loc1, Token.Cross);
            game.Board.PlacePiece(loc2, Token.Cross);
            game.Board.PlacePiece(loc3, Token.Cross);

            bool actual = game.CheckForDiagonalWin();
            
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(Location.TopLeft, Location.Centre, Location.BottomRight, true)]
        [InlineData(Location.TopRight, Location.MidRight, Location.BottomRight, true)]
        [InlineData(Location.TopLeft, Location.TopMid, Location.TopRight, true)]
        [InlineData(Location.TopLeft, Location.Centre, Location.BottomLeft, false)]
        public void CheckForWin_ShouldReturnTrueOnThreeInARow(Location loc1, Location loc2, Location loc3, bool expected)
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(loc1, Token.Cross);
            game.Board.PlacePiece(loc2, Token.Cross);
            game.Board.PlacePiece(loc3, Token.Cross);

            bool actual = game.CheckForWin();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCurrentPlayer_GivenTurnCount_ShouldReturnCurrentTurnsPlayer()
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            Player expected = game.Player1;

            Player actual = game.GetCurrentPlayer();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForDraw_GivenFullBoardWithNoWinners_ReturnsTrue()
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(Location.TopLeft, Token.Cross);
            game.Board.PlacePiece(Location.TopMid, Token.Naught);
            game.Board.PlacePiece(Location.TopRight, Token.Cross);
            game.Board.PlacePiece(Location.MidLeft, Token.Naught);
            game.Board.PlacePiece(Location.Centre, Token.Naught);
            game.Board.PlacePiece(Location.MidRight, Token.Cross);
            game.Board.PlacePiece(Location.BottomLeft, Token.Cross);
            game.Board.PlacePiece(Location.BottomMid, Token.Cross);
            game.Board.PlacePiece(Location.BottomRight, Token.Naught);
            bool expected = true;
            
            bool actual = game.CheckForDraw();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForDraw_GivenUnfinishedBoard_ReturnsFalse()
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(Location.TopLeft, Token.Cross);
            game.Board.PlacePiece(Location.TopMid, Token.Naught);
            game.Board.PlacePiece(Location.TopRight, Token.Cross);
            game.Board.PlacePiece(Location.MidLeft, Token.Naught);
            game.Board.PlacePiece(Location.Centre, Token.Naught);
            game.Board.PlacePiece(Location.MidRight, Token.Cross);
            game.Board.PlacePiece(Location.BottomLeft, Token.Cross);
            game.Board.PlacePiece(Location.BottomMid, Token.Cross);
            bool expected = false;

            bool actual = game.CheckForDraw();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForGameEnd_GivenBoardWithWin_ReturnsTrue()
        {
            ConsoleInput input = new ConsoleInput();
            Game game = new Game(_display, input, _processor);
            game.Board.PlacePiece(Location.TopLeft, Token.Cross);
            game.Board.PlacePiece(Location.TopMid, Token.Cross);
            game.Board.PlacePiece(Location.TopRight, Token.Cross);
            bool expected = true;

            bool actual = game.CheckForGameEnd();

            Assert.Equal(expected, actual);
        }
    }
}
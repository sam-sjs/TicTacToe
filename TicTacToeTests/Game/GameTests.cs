using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests.Game
{
    public class GameTests
    {
        [Fact]
        public void Game_ShouldHavePlayer1()
        {
            TicTacToe.Game.Game game = new TicTacToe.Game.Game();
            string expected = "Player 1";

            string actual = game.Player1.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_ShouldHavePlayer2()
        {
            TicTacToe.Game.Game game = new TicTacToe.Game.Game();
            string expected = "Player 2";

            string actual = game.Player2.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_PlayersShouldHaveUniqueTokens()
        {
            TicTacToe.Game.Game game = new TicTacToe.Game.Game();

            Assert.NotEqual(game.Player1.Token, game.Player2.Token);
        }

        [Fact]
        public void GetCurrentPlayer_GivenTurnCount_ShouldReturnCurrentTurnsPlayer()
        {
            TicTacToe.Game.Game game = new TicTacToe.Game.Game();
            Player expected = game.Player1;

            Player actual = game.GetCurrentPlayer();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GameEndParameters))]
        public void CheckForGameEnd_ReturnsTrue_WhenEndConditionMet(List<Token> token, bool expected)
        {
            TicTacToe.Game.Game game = new TicTacToe.Game.Game();
            game.Board.PlacePiece(Location.TopLeft, token[0]);
            game.Board.PlacePiece(Location.TopMid, token[1]);
            game.Board.PlacePiece(Location.TopRight, token[2]);
            game.Board.PlacePiece(Location.MidLeft, token[3]);
            game.Board.PlacePiece(Location.Centre, token[4]);
            game.Board.PlacePiece(Location.MidRight, token[5]);
            game.Board.PlacePiece(Location.BottomLeft, token[6]);
            game.Board.PlacePiece(Location.BottomMid, token[7]);
            game.Board.PlacePiece(Location.BottomRight, token[8]);

            bool actual = game.IsGameEnded();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MakeMove_GivenLocationInput_ShouldPlaceTokenInCorrectCell()
        {
            TicTacToe.Game.Game game = new TicTacToe.Game.Game();
            Location coords = Location.TopMid;
            Token expected = Token.Cross;

            game.MakeMove(coords);
            Token actual = game.Board.GetCellByLocation(Location.TopMid).Token;

            Assert.Equal(expected, actual);
        }
    }
}
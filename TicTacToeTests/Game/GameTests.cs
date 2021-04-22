using System.Collections.Generic;
using TicTacToe;
using TicTacToe.Game;
using Xunit;

namespace TicTacToeTests.Game
{
    public class GameTests
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;

        public GameTests()
        {
            _board = new Board();
            _player1 = new Player("Player 1", Token.Cross);
            _player2 = new Player("Player 2", Token.Naught);
        }
        
        [Fact]
        public void Game_ShouldHavePlayer1()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            ticTacToeGame.Turn = 0;
            string expected = "Player 1";
        
            string actual = ticTacToeGame.GetCurrentPlayer().Name;
        
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Game_ShouldHavePlayer2()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            ticTacToeGame.Turn = 1;
            string expected = "Player 2";
        
            string actual = ticTacToeGame.GetCurrentPlayer().Name;
        
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_PlayersShouldHaveUniqueTokens()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            Token player1Token = ticTacToeGame.GetCurrentPlayer().Token;
            ticTacToeGame.Turn = 1;
            Token player2Token = ticTacToeGame.GetCurrentPlayer().Token;

            Assert.NotEqual(player1Token, player2Token);
        }

        [Fact]
        public void GetCurrentPlayer_GivenTurnCount_ShouldReturnCurrentTurnsPlayer()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            Player expected = _player1;

            Player actual = ticTacToeGame.GetCurrentPlayer();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GameEndParameters))]
        public void CheckForGameEnd_ReturnsTrue_WhenBoardIsWinOrDraw(List<Token> token, bool expected)
        {
            _board.PlacePiece(Location.TopLeft, token[0]);
            _board.PlacePiece(Location.TopMid, token[1]);
            _board.PlacePiece(Location.TopRight, token[2]);
            _board.PlacePiece(Location.MidLeft, token[3]);
            _board.PlacePiece(Location.Centre, token[4]);
            _board.PlacePiece(Location.MidRight, token[5]);
            _board.PlacePiece(Location.BottomLeft, token[6]);
            _board.PlacePiece(Location.BottomMid, token[7]);
            _board.PlacePiece(Location.BottomRight, token[8]);
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);

            bool actual = ticTacToeGame.IsGameEnded();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForGameEnd_ReturnsTrue_WhenPlayerHasQuit()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            ticTacToeGame.PlayerHasQuit = true;

            bool actual = ticTacToeGame.IsGameEnded();
            
            Assert.True(actual);
        }

        [Fact]
        public void MakeMove_GivenLocationInput_ShouldPlaceTokenInCorrectCell()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            Location coords = Location.TopMid;
            Token expected = Token.Cross;

            ticTacToeGame.MakeMove(coords);
            Token actual = _board.GetCellByLocation(Location.TopMid).Token;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsCellEmpty_GivenLocationOfEmptyCell_ReturnsTrue()
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            Location coordsToCheck = Location.Centre;

            bool actual = ticTacToeGame.IsCellEmpty(coordsToCheck);
            
            Assert.True(actual);
        }

        [Fact]
        public void IsCellEmpty_GivenLocationOfNonEmptyCell_ReturnsFalse()
        {
            _board.PlacePiece(Location.TopLeft, Token.Cross);
            TicTacToeGame ticTacToeGame = new TicTacToeGame(_board, _player1, _player2);
            Location coordsToCheck = Location.TopLeft;

            bool actual = ticTacToeGame.IsCellEmpty(coordsToCheck);
            
            Assert.False(actual);
        }
    }
}
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void Board_ShouldInitialiseWith9Cells()
        {
            Board board = new Board();
            int expected = 9;

            int actual = board.Cells.Length;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Board_ShouldGenerateUniqueCells()
        {
            Board board = new Board();
            int numberOfCells = board.Cells.Length;

            int numberOfUniqueCells = board.Cells.Distinct().Count();

            Assert.Equal(numberOfCells, numberOfUniqueCells);
        }

        [Fact]
        public void GetCellByLocation_GivenLocation_ShouldReturnCell()
        {
            Board board = new Board();
            Cell expected = new Cell(Location.TopLeft);

            Cell actual = board.GetCellByLocation(Location.TopLeft);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlacePiece_GivenLocationAndPiece_ShouldUpdateCellWithGivenPiece()
        {
            Board board = new Board();
            Location location = Location.TopLeft;
            Token token = Token.Cross;

            board.PlacePiece(location, token);
            Cell cell = board.GetCellByLocation(location);

            Assert.Equal(token, cell.Token);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetTopLine_ShouldReturnArrayOfTopRowTokens(Token token1, Token token2, Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.TopLeft, token1);
            board.PlacePiece(Location.TopMid, token2);
            board.PlacePiece(Location.TopRight, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetTopLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetHorizontalMidLine_ShouldReturnArrayOfHorizontalMidRowTokens(Token token1, Token token2,
            Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.MidLeft, token1);
            board.PlacePiece(Location.Centre, token2);
            board.PlacePiece(Location.MidRight, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetHorizontalMidLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetBottomLine_ShouldReturnArrayOfBottomRowTokens(Token token1, Token token2, Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.BottomLeft, token1);
            board.PlacePiece(Location.BottomMid, token2);
            board.PlacePiece(Location.BottomRight, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetBottomLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetLeftLine_ShouldReturnArrayOfLeftColTokens(Token token1, Token token2, Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.TopLeft, token1);
            board.PlacePiece(Location.MidLeft, token2);
            board.PlacePiece(Location.BottomLeft, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetLeftLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetVerticalMidLine_ShouldReturnArrayOfVerticalMidColTokens(Token token1, Token token2, Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.TopMid, token1);
            board.PlacePiece(Location.Centre, token2);
            board.PlacePiece(Location.BottomMid, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetVerticalMidLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetRightLine_ShouldReturnArrayOfRightColTokens(Token token1, Token token2, Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.TopRight, token1);
            board.PlacePiece(Location.MidRight, token2);
            board.PlacePiece(Location.BottomRight, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetRightLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetTopLeftToBottomRightLine_ShouldReturnArrayOfDiagonalTokens(Token token1, Token token2,
            Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.TopLeft, token1);
            board.PlacePiece(Location.Centre, token2);
            board.PlacePiece(Location.BottomRight, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetTopLeftToBottomRightLine();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Token.Empty, Token.Empty, Token.Empty)]
        [InlineData(Token.Cross, Token.Naught, Token.Empty)]
        public void GetTopRightToBottomLeftLine_ShouldReturnArrayOfDiagonalTokens(Token token1, Token token2,
            Token token3)
        {
            Board board = new Board();
            board.PlacePiece(Location.TopRight, token1);
            board.PlacePiece(Location.Centre, token2);
            board.PlacePiece(Location.BottomLeft, token3);
            Token[] expected = new Token[] {token1, token2, token3};

            Token[] actual = board.GetTopRightToBottomLeftLine();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFullBoard_ShouldReturnArrayOfAllBoardTokens()
        {
            Board board = new Board();
            board.PlacePiece(Location.TopLeft, Token.Cross);
            board.PlacePiece(Location.TopMid, Token.Naught);
            board.PlacePiece(Location.TopRight, Token.Cross);
            board.PlacePiece(Location.MidLeft, Token.Naught);
            board.PlacePiece(Location.Centre, Token.Empty);
            board.PlacePiece(Location.MidRight, Token.Empty);
            board.PlacePiece(Location.BottomLeft, Token.Empty);
            board.PlacePiece(Location.BottomMid, Token.Empty);
            board.PlacePiece(Location.BottomRight, Token.Empty);
            Token[] expected = new Token[]
            {
                Token.Cross, Token.Naught, Token.Cross, Token.Naught, Token.Empty,
                Token.Empty, Token.Empty, Token.Empty, Token.Empty
            };

            Token[] actual = board.GetFullBoard();
            
            Assert.Equal(expected, actual);
        }
    }
}
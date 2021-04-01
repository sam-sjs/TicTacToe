using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CellTests
    {
        [Theory]
        [InlineData(Piece.Cross, "X")]
        [InlineData(Piece.Naught, "0")]
        [InlineData(Piece.Empty, ".")]
        public void ToString_ReturnsPieceValueAsString(Piece piece, string expected)
        {
            Cell cell = new Cell(Location.TopLeft);
            cell.Piece = piece;

            string actual = cell.ToString();
    
            Assert.Equal(expected, actual);
        }
    }
}
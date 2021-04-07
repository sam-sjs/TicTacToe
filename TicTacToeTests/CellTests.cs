using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CellTests
    {
        [Theory]
        [InlineData(Token.Cross, "X")]
        [InlineData(Token.Naught, "0")]
        [InlineData(Token.Empty, ".")]
        public void ToString_ReturnsPieceValueAsString(Token token, string expected)
        {
            Cell cell = new Cell(Location.TopLeft);
            cell.Token = token;

            string actual = cell.ToString();
    
            Assert.Equal(expected, actual);
        }
    }
}
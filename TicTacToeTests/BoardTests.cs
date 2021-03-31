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
    }
}
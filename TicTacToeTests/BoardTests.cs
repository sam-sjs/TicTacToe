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
        public void GetPiece_GivenLocation_ShouldReturnCell()
        {
            Board board = new Board();
            Cell expected = new Cell(Location.TopLeft);

            Cell actual = board.GetCellByLocation(Location.TopLeft);

            Assert.Equal(expected, actual);
        }
    }
}
using System;

namespace TicTacToe
{
    public class Board
    {
        private const int BoardSize = 9;

        public Board()
        {
            // Write test to check cells have unique positions
            foreach (Location loc in Enum.GetValues(typeof(Location)))
            {
                Cells[(int)loc] = new Cell(loc);
            }
        }
        public Cell[] Cells { get; set; } = new Cell[BoardSize];
    }
}
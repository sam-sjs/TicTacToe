using System;

namespace TicTacToe
{
    public class Board
    {
        private const int BoardSize = 9;

        public Board()
        {
            foreach (Location loc in Enum.GetValues(typeof(Location)))
            {
                Cells[(int)loc] = new Cell(loc);
            }
        }
        public Cell[] Cells { get; } = new Cell[BoardSize];
    }
}
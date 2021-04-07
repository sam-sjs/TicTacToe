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

        public Cell GetCellByLocation(Location location)
        {
            return Array.Find(Cells, cell => cell.Location == location);
        }

        public void PlacePiece(Location location, Piece piece)
        {
            Cell cell = GetCellByLocation(location);
            cell.Piece = piece;
        }

        public override string ToString()
        {
            return
                $"{GetCellByLocation(Location.TopLeft)} {GetCellByLocation(Location.TopMid)} {GetCellByLocation(Location.TopRight)}\n" +
                $"{GetCellByLocation(Location.MidLeft)} {GetCellByLocation(Location.Centre)} {GetCellByLocation(Location.MidRight)}\n" +
                $"{GetCellByLocation(Location.BottomLeft)} {GetCellByLocation(Location.BottomMid)} {GetCellByLocation(Location.BottomRight)}";
        }
    }
}
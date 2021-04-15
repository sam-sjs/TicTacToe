using System;
using System.Linq;

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

        public void PlacePiece(Location location, Token token)
        {
            Cell cell = GetCellByLocation(location);
            cell.Token = token;
        }

        public Token[] GetTopLine()
        {
            return new[]
            {
                GetCellByLocation(Location.TopLeft).Token,
                GetCellByLocation(Location.TopMid).Token,
                GetCellByLocation(Location.TopRight).Token
            };
        }
        
        public Token[] GetHorizontalMidLine()
        {
            return new[]
            {
                GetCellByLocation(Location.MidLeft).Token,
                GetCellByLocation(Location.Centre).Token,
                GetCellByLocation(Location.MidRight).Token
            };
        }
        
        public Token[] GetBottomLine()
        {
            return new[]
            {
                GetCellByLocation(Location.BottomLeft).Token,
                GetCellByLocation(Location.BottomMid).Token,
                GetCellByLocation(Location.BottomRight).Token
            };
        }
        
        public Token[] GetLeftLine()
        {
            return new[]
            {
                GetCellByLocation(Location.TopLeft).Token,
                GetCellByLocation(Location.MidLeft).Token,
                GetCellByLocation(Location.BottomLeft).Token
            };
        }
        
        public Token[] GetVerticalMidLine()
        {
            return new[]
            {
                GetCellByLocation(Location.TopMid).Token,
                GetCellByLocation(Location.Centre).Token,
                GetCellByLocation(Location.BottomMid).Token
            };
        }
        
        public Token[] GetRightLine()
        {
            return new[]
            {
                GetCellByLocation(Location.TopRight).Token,
                GetCellByLocation(Location.MidRight).Token,
                GetCellByLocation(Location.BottomRight).Token
            };
        }
        
        public Token[] GetTopLeftToBottomRightLine()
        {
            return new[]
            {
                GetCellByLocation(Location.TopLeft).Token,
                GetCellByLocation(Location.Centre).Token,
                GetCellByLocation(Location.BottomRight).Token
            };
        }
        
        public Token[] GetTopRightToBottomLeftLine()
        {
            return new[]
            {
                GetCellByLocation(Location.TopRight).Token,
                GetCellByLocation(Location.Centre).Token,
                GetCellByLocation(Location.BottomLeft).Token
            };
        }

        public Token[] GetFullBoard()
        {
            return GetTopLine().Concat(GetHorizontalMidLine().Concat(GetBottomLine())).ToArray();
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
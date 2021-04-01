
using System;

namespace TicTacToe
{
    public class Cell
    {
        public Cell(Location location)
        {
            Location = location;
        }

        public Location Location { get; }
        public Piece Piece { get; set; } = Piece.Empty;

        protected bool Equals(Cell other)
        {
            return Location == other.Location;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            return (int) Location;
        }

        public override string ToString()
        {
            switch (this.Piece)
            {
                case Piece.Cross:
                    return "X";
                case Piece.Naught:
                    return "0";
                case Piece.Empty:
                    return ".";
                default:
                    return ".";
            }
        }
    }
}
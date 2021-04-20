
namespace TicTacToe
{
    public class Cell
    {
        public Cell(Location location)
        {
            Location = location;
        }

        public Location Location { get; }
        public Token Token { get; set; } = Token.Empty;

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
            return Token switch
            {
                Token.Cross => "X",
                Token.Naught => "0",
                Token.Empty => ".",
                _ => "."
            };
        }
    }
}
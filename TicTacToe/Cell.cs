
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
    }
}
using System;
using TicTacToe.Output;

namespace TicTacToe
{
    public class Display
    {
        private IOutput _output;

        public Display(IOutput output)
        {
            _output = output;
        }

        public void Welcome()
        {
            _output.WriteLine(Messages.Welcome);
            _output.WriteLine();
            _output.WriteLine(Messages.AnnounceBoard);
        }

        public void Board(Board board)
        {
            _output.WriteLine($"{board.GetCellByLocation(Location.TopLeft)} {board.GetCellByLocation(Location.TopMid)} {board.GetCellByLocation(Location.TopRight)}");
            _output.WriteLine($"{board.GetCellByLocation(Location.MidLeft)} {board.GetCellByLocation(Location.Centre)} {board.GetCellByLocation(Location.MidRight)}");
            _output.WriteLine($"{board.GetCellByLocation(Location.BottomLeft)} {board.GetCellByLocation(Location.BottomMid)} {board.GetCellByLocation(Location.BottomRight)}");
        }

        public void AskForCoordinates()
        {

            _output.WriteLine("Player 1" + Messages.AskForCoords);
        }

        public void InvalidCoordinates()
        {
            _output.WriteLine(Messages.InvalidCoords);
        }
 
        public void MoveAccepted()
        {
            _output.WriteLine(Messages.MoveAccepted);
        }
    }
}
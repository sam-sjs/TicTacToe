using TicTacToe.Output;

namespace TicTacToe
{
    public class Display
    {
        private readonly IOutput _output;

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
            _output.WriteLine(board.ToString());
        }

        public void AskForCoordinates(string player)
        {

            _output.WriteLine(player + Messages.AskForCoords);
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
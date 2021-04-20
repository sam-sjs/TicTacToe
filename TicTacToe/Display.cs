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

        public void Board(string board)
        {
            _output.WriteLine(board);
        }

        public void AskPlayerForCoordinates(Player player)
        {

            _output.WriteLine(Messages.AskForCoords, player.Name, player.Token.ToString());
        }

        public void InvalidCoordinates()
        {
            _output.WriteLine(Messages.InvalidCoords);
        }
 
        public void MoveAccepted()
        {
            _output.WriteLine(Messages.MoveAccepted);
        }

        public void Winner()
        {
            _output.WriteLine(Messages.Winner);
        }

        public void GameDrawn()
        {
            _output.WriteLine(Messages.GameDrawn);
        }
    }
}
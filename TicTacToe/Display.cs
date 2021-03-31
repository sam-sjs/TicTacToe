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

        public void Board()
        {
            _output.WriteLine(". . .");
            _output.WriteLine(". . .");
            _output.WriteLine(". . .");
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
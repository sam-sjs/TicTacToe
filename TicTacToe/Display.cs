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
            _output.WriteLine("Welcome to Tic Tac Toe!");
            _output.WriteLine();
            _output.WriteLine("Here's the current board:");
        }

        public void Board()
        {
            _output.WriteLine(". . .");
            _output.WriteLine(". . .");
            _output.WriteLine(". . .");
        }

        public void AskForCoordinate()
        {

            _output.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up:");
        }
    }
}
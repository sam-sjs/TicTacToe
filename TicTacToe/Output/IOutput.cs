namespace TicTacToe.Output
{
    public interface IOutput
    {
        public void WriteLine();
        public void WriteLine(string message);
        public void WriteLine(string template, string arg1, string arg2);
    }
}
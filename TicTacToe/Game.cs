
namespace TicTacToe
{
    public class Game
    {
        public Game(Display message, IInput input)
        {
            Display = message;
            Input = input;
        }

        public Display Display { get; }
        public IInput Input { get; }
        public void Play()
        {
            Display.Welcome();
            Display.Board();
            Display.AskForCoordinate();
            string coord = Input.ReadLine();
        }
    }
}
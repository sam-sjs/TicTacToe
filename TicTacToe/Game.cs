
using System.Text.RegularExpressions;

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
            string coords = GetCoordinates();
        }

        public string GetCoordinates()
        {
            string coordPattern = @"^[123],[123]$";
            string coords;
            Display.AskForCoordinates();
            while (true)
            {
                coords = Input.ReadLine();
                if (Regex.IsMatch(coords, coordPattern)) break;
                Display.InvalidCoordinates();
            }

            return coords;
        }
    }
}
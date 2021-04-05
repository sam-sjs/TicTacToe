using System.Text.RegularExpressions;
using TicTacToe.Input;

namespace TicTacToe
{
    public class Coordinates
    {
        public Coordinates(Display display, IInput input)
        {
            Display = display;
            Input = input;
        }

        public Display Display { get; }
        public IInput Input { get; }

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

using System.Collections.Generic;
using System.Text.RegularExpressions;
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        public Game(Display display, IInput input, Board board)
        {
            Display = display;
            Input = input;
            Board = board;
        }

        public Display Display { get; }
        public IInput Input { get; }
        public Board Board { get; }
        public void Play()
        {
            Display.Welcome();
            Display.Board(Board);
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

        // Should I extract this table to its own class
        public Location ConvertCoordinates(string coords)
        {
            Dictionary<string, Location> locationTable = new Dictionary<string, Location>
            {
                {"1,1", Location.TopLeft}, {"1,2", Location.TopMid}, {"1,3", Location.TopRight},
                {"2,1", Location.MidLeft}, {"2,2", Location.Centre}, {"2,3", Location.MidRight},
                {"3,1", Location.BottomLeft}, {"3,2", Location.BottomMid}, {"3,3", Location.BottomRight}
            };

            return locationTable[coords];
        }
    }
}
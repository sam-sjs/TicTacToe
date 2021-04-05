
using System.Collections.Generic;
using TicTacToe.Input;

namespace TicTacToe
{
    public class Game
    {
        public Game(Display display, IInput input, Board board, Coordinates coordinates)
        {
            Display = display;
            Input = input;
            Board = board;
            Coordinates = coordinates;
        }

        public Display Display { get; }
        public IInput Input { get; }
        public Board Board { get; }
        public Coordinates Coordinates { get; }
        public void Play()
        {
            Display.Welcome();
            Display.Board(Board);
            string coords = Coordinates.GetCoordinates();
        }


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
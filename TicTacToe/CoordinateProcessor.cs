using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class CoordinateProcessor
    {
        private const string CoordinatePattern = @"^[123],[123]$";
        private readonly Dictionary<string, Location> _locationTable = new Dictionary<string, Location>
        {
            {"1,1", Location.TopLeft}, {"1,2", Location.TopMid}, {"1,3", Location.TopRight},
            {"2,1", Location.MidLeft}, {"2,2", Location.Centre}, {"2,3", Location.MidRight},
            {"3,1", Location.BottomLeft}, {"3,2", Location.BottomMid}, {"3,3", Location.BottomRight}
        };

        public bool IsCoordinateValid(string coords)
        {
            return Regex.IsMatch(coords, CoordinatePattern);
        }
        
        public Location ConvertCoordinate(string coords)
        {
            return _locationTable[coords];
        }
    }
} 
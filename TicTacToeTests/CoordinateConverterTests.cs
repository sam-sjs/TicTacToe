using System.Collections.Generic;
using TicTacToe;
using TicTacToe.Input;
using Xunit;

namespace TicTacToeTests
{
    public class CoordinateConverterTests
    {
        [Fact]
        public void GetLocation_GivenStringCoordinates_ShouldReturnLocation()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            Coordinates coordinates = new Coordinates(display, input);
            Location expected = Location.TopMid;

            Location actual = coordinates.GetLocation();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetInputs()
        {
            yield return new object[] {new List<string> {"1,Q", "1,2"}, "1,2"};
            yield return new object[] {new List<string> {"Q,2", "2,3"}, "2,3"};
            yield return new object[] {new List<string> {"12,2", "1,1"}, "1,1"};
            yield return new object[] {new List<string> {"1,8", "4,4", "1,2"}, "1,2"};
        }
        
        [Theory]
        [MemberData(nameof(GetInputs))]
        public void GetCoordinates_GivenInvalidInput_ShouldAwaitValidInput(List<string> inputs, string expected)
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            Coordinates coordinates = new Coordinates(display, input);

            string actual = coordinates.GetCoordinates();

            Assert.Equal(expected, actual);
        }
        
        public static IEnumerable<object[]> GetInvalidInputs()
        {
            yield return new object[] {new List<string> {"1,Q"}, null};
            yield return new object[] {new List<string> {"1,4"}, null};
        }

        [Theory]
        [MemberData(nameof(GetInvalidInputs))]
        public void ValidateCoordinates_ShouldReturnNullOnInvalidInput(List<string> inputs, string expected)
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            TestInput input = new TestInput(inputs);
            Coordinates coordinates = new Coordinates(display, input);

            string actual = coordinates.ValidateCoordinates();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ConvertCoordinates_GivenStringCoords_ShouldReturnLocation()
        {
            TestOutput output = new TestOutput();
            Display display = new Display(output);
            ConsoleInput input = new();
            Coordinates coordinates = new Coordinates(display, input);
            string coordsToConvert = "1,2";
            Location expected = Location.TopMid;

            Location actual = coordinates.ConvertCoordinates(coordsToConvert);

            Assert.Equal(expected, actual);
        }
    }
}
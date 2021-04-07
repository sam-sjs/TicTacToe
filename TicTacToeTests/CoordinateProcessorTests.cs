using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CoordinateConverterTests
    {
        [Theory]
        [InlineData("Q,3", false)]
        [InlineData("1,5", false)]
        [InlineData("2,2", true)]
        public void ValidateCoordinates_GivenValidCoords_ShouldReturnTrue(string input, bool expected)
        {
            CoordinateProcessor processor = new CoordinateProcessor();

            bool actual = processor.ValidateCoordinates(input);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ConvertCoordinates_GivenStringCoords_ShouldReturnLocation()
        {
            CoordinateProcessor processor = new CoordinateProcessor();
            string input = "1,2";
            Location expected = Location.TopMid;

            Location actual = processor.ConvertCoordinates(input);

            Assert.Equal(expected, actual);
        }
    }
}
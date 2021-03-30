
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void GetCoordinate_ShouldReturnString()
        {
            string expected = "1,2";
            TestOutput output = new TestOutput();
            Display message = new Display(output);
            TestInput input = new TestInput(expected);
            Game game = new Game(message, input);

            string actual = game.Input.ReadLine();

            Assert.Equal(expected, actual);
        }
    }
}
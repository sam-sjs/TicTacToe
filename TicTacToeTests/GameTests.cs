
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void ReadLine_ShouldReturnExpectedString()
        {
            List<string> inputs = new List<string> {"1,2"};
            TestOutput output = new TestOutput();
            Display message = new Display(output);
            TestInput input = new TestInput(inputs);
            Game game = new Game(message, input);
            string expected = "1,2"; 

            string actual = game.Input.ReadLine();

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
        public void GetCoordinate_GivenIncorrectInput_ShouldAwaitValidInput(List<string> inputs, string expected)
        {
            TestOutput output = new TestOutput();
            Display message = new Display(output);
            TestInput input = new TestInput(inputs);
            Game game = new Game(message, input);

            string actual = game.GetCoordinates();

            Assert.Equal(expected, actual);
        }
    }
}
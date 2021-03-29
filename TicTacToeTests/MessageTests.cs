using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class MessageTests
    {
        [Fact]
        public void DisplayWelcome_ShouldHaveCorrectMessage()
        {
            TestOutput output = new TestOutput();
            Message newMessage = new Message(output);
            string expected = "Welcome to Tic Tac Toe!";

            newMessage.DisplayWelcome();

            Assert.Equal(expected, output.Message);
        }
    }
}
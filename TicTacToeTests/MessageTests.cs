using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class MessageTests
    {
        [Fact]
        public void DisplayWelcome_ShouldHaveCorrectMessage()
        {
            List<string> expectedMessages = new List<string>
            {
                "Welcome to Tic Tac Toe!",
                "",
                "Here's the current board:"
            };
            TestOutput output = new TestOutput();
            Message newMessage = new Message(output);
            
            
            newMessage.Welcome();

            Assert.Equal(expectedMessages, output.Messages);
        }

        [Fact]
        public void DisplayBoard_ShouldDisplayNineEmptyCells()
        {
            List<string> expected = new List<string>
            {
                ". . .",
                ". . .",
                ". . ."
            };
            
            TestOutput output = new TestOutput();
            Message newMessage = new Message(output);

            newMessage.Board();

            Assert.Equal(expected, output.Messages);
        }
    }
}
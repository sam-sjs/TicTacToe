using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class DisplayTests
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
            Display newMessage = new Display(output);
            
            
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
            Display newMessage = new Display(output);

            newMessage.Board();

            Assert.Equal(expected, output.Messages);
        }

        [Fact]
        public void AskForCoordinate()
        {
            List<string> expected = new List<string>
                {"Player 1 enter a coord x,y to place your X or enter 'q' to give up:"};
            TestOutput output = new TestOutput();
            Display newMessage = new Display(output);

            newMessage.AskForCoordinate();
            
            Assert.Equal(expected, output.Messages);
        }
    }
}
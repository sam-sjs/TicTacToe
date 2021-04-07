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
            List<string> expected = new List<string> {". . .\n. . .\n. . ."};
            
            TestOutput output = new TestOutput();
            Display newMessage = new Display(output);
            Board board = new Board();

            newMessage.Board(board);

            Assert.Equal(expected, output.Messages);
        }

        [Fact]
        public void AskForCoordinate_ShouldHaveCorrectMessage()
        {
            string input = "Player 1";
            List<string> expected = new List<string>
                {$"{input} enter a coord x,y to place your X or enter 'q' to give up:"};
            TestOutput output = new TestOutput();
            Display newMessage = new Display(output);

            newMessage.AskForCoordinates(input);
            
            Assert.Equal(expected, output.Messages);
        }

        [Fact]
        public void InvalidCoordinates_ShouldHaveCorrectMessage()
        {
            List<string> expected = new List<string> {"Oh no!  Those coordinates are not valid, please try again:"};
            TestOutput output = new TestOutput();
            Display newMessage = new Display(output);

            newMessage.InvalidCoordinates();
            
            Assert.Equal(expected, output.Messages);
        }
        
        [Fact]
        public void MoveAccepted_ShouldHaveCorrectMessage()
        {
            List<string> expected = new List<string> {"Move accepted, here's the current board:"};
            TestOutput output = new TestOutput();
            Display newMessage = new Display(output);

            newMessage.MoveAccepted();
            
            Assert.Equal(expected, output.Messages);
        }
    }
}
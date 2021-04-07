using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_ShouldHaveName()
        {
            Player player = new Player("Player 1", Token.Cross);
            string expected = "Player 1";

            string actual = player.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Player_ShouldHaveToken()
        {
            Player player = new Player("Player 1", Token.Cross);
            Token expected = Token.Cross;

            Token actual = player.Token;

            Assert.Equal(expected, actual);
        }
    }
}
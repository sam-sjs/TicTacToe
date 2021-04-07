namespace TicTacToe
{
    public class Player
    {
        public Player(string name, Token token)
        {
            Name = name;
            Token = token;
        }

        public string Name { get; }
        public Token Token { get; }
    }
}
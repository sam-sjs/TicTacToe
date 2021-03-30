
namespace TicTacToe
{
    public class Game
    {
        public Game(Message message)
        {
            Message = message;
        }

        public Message Message { get; }

        public void Play()
        {
            Message.Welcome();
            Message.Board();
        }
    }
}
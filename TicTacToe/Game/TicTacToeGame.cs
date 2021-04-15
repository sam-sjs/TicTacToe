using System.Linq;

namespace TicTacToe.Game
{
    public class TicTacToeGame
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        public TicTacToeGame(Board board, Player player1, Player player2)
        {
            _board = board;
            _player1 = player1;
            _player2 = player2;
        }

        public int Turn { get; set; } = 0;
        public bool PlayerHasQuit { get; set; } = false;

        public bool IsGameEnded()
        {
            return IsGameWon() ||
                   IsGameADraw() ||
                   PlayerHasQuit;
        }

        private bool IsGameWon()
        {
            return IsWinningHorizontal() ||
                   IsWinningVertical() ||
                   IsWinningDiagonal();
        }

        private bool IsWinningHorizontal()
        {
            return IsWinningLine(_board.GetTopLine()) ||
                   IsWinningLine(_board.GetHorizontalMidLine()) ||
                   IsWinningLine(_board.GetBottomLine());
        }

        private bool IsWinningLine(Token[] line)
        {
            Token first = line.First();
            return line.All(token => token == first && first != Token.Empty);
        }

        private bool IsWinningVertical()
        {
            return IsWinningLine(_board.GetLeftLine()) ||
                   IsWinningLine(_board.GetVerticalMidLine()) ||
                   IsWinningLine(_board.GetRightLine());
        }

        private bool IsWinningDiagonal()
        {
            return IsWinningLine(_board.GetTopLeftToBottomRightLine()) ||
                   IsWinningLine(_board.GetTopRightToBottomLeftLine());
        }

        private bool IsGameADraw()
        {
            return _board.GetFullBoard().All(token => token != Token.Empty);
        }

        public void MakeMove(Location location)
        {
            _board.PlacePiece(location, GetCurrentPlayer().Token);
        }

        public Player GetCurrentPlayer()
        {
            return Turn % 2 == 0 ? _player1 : _player2;
        }

        public string GetBoardDisplay()
        {
            return _board.ToString();
        }
    }
}
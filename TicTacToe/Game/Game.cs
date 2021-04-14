using System.Linq;

namespace TicTacToe.Game
{
    public class Game
    {
        public Game()
        {
            Board = new Board();
            Player1 = new Player("Player 1", Token.Cross);
            Player2 = new Player("Player 2", Token.Naught);
        }

        public Board Board { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
        public int Turn { get; set; } = 0;
        public bool PlayerHasQuit { get; set; } = false;

        public bool IsGameEnded()
        {
            return IsGameWon() ||
                   IsGameADraw();
        }

        private bool IsGameWon()
        {
            return IsWinningHorizontal() ||
                   IsWinningVertical() ||
                   IsWinningDiagonal();
        }

        private bool IsWinningHorizontal()
        {
            return IsWinningLine(Board.GetTopLine()) ||
                   IsWinningLine(Board.GetHorizontalMidLine()) ||
                   IsWinningLine(Board.GetBottomLine());
        }

        private bool IsWinningLine(Token[] line)
        {
            Token first = line.First();
            return line.All(token => token == first && first != Token.Empty);
        }

        private bool IsWinningVertical()
        {
            return IsWinningLine(Board.GetLeftLine()) ||
                   IsWinningLine(Board.GetVerticalMidLine()) ||
                   IsWinningLine(Board.GetRightLine());
        }

        private bool IsWinningDiagonal()
        {
            return IsWinningLine(Board.GetTopLeftToBottomRightLine()) ||
                   IsWinningLine(Board.GetTopRightToBottomLeftLine());
        }

        private bool IsGameADraw()
        {
            return Board.Cells.All(cell => cell.Token != Token.Empty);
        }

        public void MakeMove(Location location)
        {
            Board.PlacePiece(location, GetCurrentPlayer().Token);
        }

        public Player GetCurrentPlayer()
        {
            return Turn % 2 == 0 ? Player1 : Player2;
        }

        public string GetBoardDisplay()
        {
            return Board.ToString();
        }
    }
}
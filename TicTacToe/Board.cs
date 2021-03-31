namespace TicTacToe
{
    public class Board
    {
        private const int BoardSize = 9;

        public Board()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                Cells[i] = new Cell();
            }
        }
        public Cell[] Cells { get; set; } = new Cell[BoardSize];
    }
}
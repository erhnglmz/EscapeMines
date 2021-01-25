using EscapeMines.Abstractions;
using EscapeMines.Models;

namespace EscapeMines.Services
{
    public class BoardService : IBoardService
    {
        public Board CreateBoard(int x, int y)
        {
            return new Board(x, y);
        }

        public bool CheckIfPointInsideTheBoard(Board board, Point p)
        {
            return board.CheckIfPointInside(p);
        }
    }
}

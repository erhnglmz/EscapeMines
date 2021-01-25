using EscapeMines.Models;

namespace EscapeMines.Abstractions
{
    public interface IBoardService
    {
        Board CreateBoard(int x, int y);
        bool CheckIfPointInsideTheBoard(Board board, Point p);
    }
}

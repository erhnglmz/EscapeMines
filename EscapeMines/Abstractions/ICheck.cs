using EscapeMines.Models;

namespace EscapeMines.Abstractions
{
    public interface ICheck
    {
        void CheckIfMovementInsideBoard(Position currentPosition, Board board);
    }
}

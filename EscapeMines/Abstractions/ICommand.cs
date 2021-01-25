using EscapeMines.Models;

namespace EscapeMines.Abstractions
{
    public interface ICommand
    {
        Position Apply(Position position);
    }
}

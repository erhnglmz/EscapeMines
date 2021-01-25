using EscapeMines.Models;

namespace EscapeMines.Abstractions
{
    public interface IMineService
    {
        Mine CreateMine(int x, int y);
    }
}

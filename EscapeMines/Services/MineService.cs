using EscapeMines.Abstractions;
using EscapeMines.Models;

namespace EscapeMines.Services
{
    public class MineService : IMineService
    {
        public Mine CreateMine(int x, int y)
        {
            return new Mine(x, y);
        }
    }
}

using System.Collections.Generic;
using EscapeMines.Enums;
using EscapeMines.Models;

namespace EscapeMines.Abstractions
{
    public interface ITurtleService
    {
        Turtle CreateTurtle(int x, int y, string heading);
        Result ApplyCommand(string commandString, ExitGate exitGate, List<Mine> mines, Board board, Turtle turtle);
    }
}

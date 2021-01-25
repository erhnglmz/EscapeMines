using System;
using System.Collections.Generic;
using System.Linq;
using EscapeMines.Abstractions;
using EscapeMines.Commands;
using EscapeMines.Enums;
using EscapeMines.Models;
using Action = EscapeMines.Enums.Action;

namespace EscapeMines.Services
{
    public class TurtleService : ITurtleService
    {
        public Turtle CreateTurtle(int x, int y, string heading)
        {
            return new Turtle(x, y, heading);
        }

        public Result ApplyCommand(string commandString, ExitGate exitGate, List<Mine> mines, Board board, Turtle turtle)
        {
            List<ICommand> commandList = new List<ICommand>();

            var commands = commandString.Split(' ').ToList().ConvertAll(x => (Action)Enum.Parse(typeof(Action), x));

            foreach (var item in commands)
            {
                switch (item)
                {
                    case Action.L:
                        commandList.Add(new TurnLeft());
                        break;
                    case Action.R:
                        commandList.Add(new TurnRight());
                        break;
                    case Action.M:
                        commandList.Add(new Move(board));
                        break;
                    default:
                        break;
                }
            }

            foreach (var command in commandList)
            {
                turtle.Position = command.Apply(turtle.Position);
                if (mines.Any(x => x.Location.X == turtle.Position.Location.X && x.Location.Y == turtle.Position.Location.Y))
                    return Result.MineHit;
            }

            if (turtle.Position.Location.X == exitGate.Location.X && turtle.Position.Location.Y == exitGate.Location.Y)
                return Result.Success;

            return Result.StillInDanger;

        }
    }
}

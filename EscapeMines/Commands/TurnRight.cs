using EscapeMines.Abstractions;
using EscapeMines.Enums;
using EscapeMines.Models;

namespace EscapeMines.Commands
{
    public class TurnRight : ICommand
    {
        public Position Apply(Position position)
        {
            switch (position.Heading)
            {
                case Directions.N:
                    position.Heading = Directions.E;
                    break;
                case Directions.E:
                    position.Heading = Directions.S;
                    break;
                case Directions.S:
                    position.Heading = Directions.W;
                    break;
                case Directions.W:
                    position.Heading = Directions.N;
                    break;
                default:
                    break;
            }

            return position;
        }
    }
}

using EscapeMines.Abstractions;
using EscapeMines.Enums;
using EscapeMines.Models;

namespace EscapeMines.Commands
{
    public class TurnLeft : ICommand
    {
        public Position Apply(Position position)
        {
            switch (position.Heading)
            {
                case Directions.N:
                    position.Heading = Directions.W;
                    break;
                case Directions.E:
                    position.Heading = Directions.N;
                    break;
                case Directions.S:
                    position.Heading = Directions.E;
                    break;
                case Directions.W:
                    position.Heading = Directions.S;
                    break;
                default:
                    break;
            }

            return position;
        }
    }
}

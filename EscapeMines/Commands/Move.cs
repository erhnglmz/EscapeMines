using EscapeMines.Abstractions;
using EscapeMines.Enums;
using EscapeMines.Exceptions;
using EscapeMines.Models;

namespace EscapeMines.Commands
{
    public class Move : ICommand, ICheck
    {
        public Move(Board board)
        {
            this.Board = board;
        }

        public Board Board { get; set; }
        public Position Apply(Position position)
        {
            switch (position.Heading)
            {
                case Directions.N:
                    position.Location.Y++;
                    break;
                case Directions.E:
                    position.Location.X++;
                    break;
                case Directions.S:
                    position.Location.Y--;
                    break;
                case Directions.W:
                    position.Location.X--;
                    break;
                default:
                    break;
            }
            CheckIfMovementInsideBoard(position, Board);

            return position;
        }

        public void CheckIfMovementInsideBoard(Position currentPosition, Board board)
        {
            if (currentPosition.Location.X > board.TopRight.X || currentPosition.Location.Y > board.TopRight.Y)
                throw new TurtleOutOfBoardException("Turtle can not move to out of minefield, please correct the command text file and retry!");
        }
    }
}

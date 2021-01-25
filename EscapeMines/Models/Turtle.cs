using System;
using EscapeMines.Enums;

namespace EscapeMines.Models
{
    public class Turtle
    {
        public Turtle(int x, int y, string heading)
        {
            this.Position = new Position
            {
                Location = new Point()
                {
                    X = x,
                    Y = y
                }
            };
            Position.Heading = (Directions)Enum.Parse(typeof(Directions), heading);
        }
        public Position Position { get; set; }

    }
}

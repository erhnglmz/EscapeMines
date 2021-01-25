using EscapeMines.Enums;

namespace EscapeMines.Models
{
    public class Position
    {
        public Position()
        {
            Location = new Point();
        }

        public Point Location { get; set; }
        public Directions Heading { get; set; }


    }
}

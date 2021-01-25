namespace EscapeMines.Models
{
    public class Board
    {
        public Board(int x, int y)
        {
            this.TopRight = new Point
            {
                X = x,
                Y = y
            };
        }
        public Point TopRight { get; set; }

        public bool CheckIfPointInside(Point p)
        {
            return p.X <= this.TopRight.X && p.Y <= this.TopRight.Y;
        }
    }
}

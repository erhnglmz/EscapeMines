namespace EscapeMines.Models
{
    public class Mine
    {
        public Mine(int x, int y)
        {
            this.Location = new Point()
            {
                X = x,
                Y = y
            };
        }
        public Point Location { get; set; }


    }
}

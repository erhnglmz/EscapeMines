namespace EscapeMines.Models
{
    public class ExitGate
    {
        public ExitGate(int x, int y)
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

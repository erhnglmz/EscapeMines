using System;

namespace EscapeMines.Exceptions
{
    public class TurtleOutOfBoardException : Exception
    {
        public TurtleOutOfBoardException(string message)  : base(message)
        {
            Console.WriteLine(message);
        }
    }
}

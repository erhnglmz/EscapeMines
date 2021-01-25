using System;

namespace EscapeMines.Exceptions
{
    public class MineOutOfBoardException : Exception
    {
        public MineOutOfBoardException(string message): base(message)
        {
            Console.WriteLine(message);
        }
    }
}

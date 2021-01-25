using System;

namespace EscapeMines.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException(string message): base(message)
        {
            Console.WriteLine(message);
        }
    }
}

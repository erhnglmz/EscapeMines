using System.IO;
using EscapeMines.Abstractions;

namespace EscapeMines.Services
{
    public class FileService : IFileService
    {
        public string[] GetFile(string path)
        {
            string text = File.ReadAllText(path);
            var textRows = text.Split("\r\n");

            return textRows;
        }
    }
}

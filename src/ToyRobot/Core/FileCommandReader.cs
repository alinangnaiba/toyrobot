using ToyRobot.Core.Interface;

namespace ToyRobot.Core
{
    public class FileCommandReader : ICommandReader
    {
        private readonly string _filePath;

        public FileCommandReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<string> ReadCommands()
        {
            var commands = File.ReadLines(_filePath).Select(x => x.ToUpper());
            return commands;
        }

        public string GetFilePath()
        {
            return _filePath;
        }
    }
}

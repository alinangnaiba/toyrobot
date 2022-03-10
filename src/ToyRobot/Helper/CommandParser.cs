using ToyRobot.Core.Model;
using ToyRobot.Enums;

namespace ToyRobot.Helper
{
    public static class CommandParser
    {
        private static List<string> _commands = new List<string> { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT"};
        public static (Location, Direction) GetStartLocationAndDirection(string command)
        {
            var commandSubstring = command.ToUpper().Split(" ");
            if (commandSubstring.Length < 1)
                throw new ArgumentException($"Invalid place command. Command: {command}");

            var subString = commandSubstring[1].Split(",");
            if (subString.Length < 3)
                throw new ArgumentException($"Invalid place command. Command: {command}");

            var location = new Location();
            location.X = Convert.ToInt32(subString[0]);
            location.Y = Convert.ToInt32(subString[1]);
            if (!Enum.TryParse<Direction>(subString[2], out var direction))
                throw new ArgumentException($"Invalid place command. Command: {command}");

            return (location, direction);
        }

        public static string Parse(string command)
        {
            var parsedCommand = command.Split(' ');
            return parsedCommand[0];
        }

        public static bool IsValidCommand(string command)
        {
            return _commands.Contains(command);
        }
    }
}

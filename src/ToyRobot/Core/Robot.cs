using ToyRobot.Core.Interface;
using ToyRobot.Core.Model;
using ToyRobot.Enums;

namespace ToyRobot.Core
{
    public class Robot : IRobot
    {
        private readonly IRobotEngine _engine;
        
        public Robot(IRobotEngine engine)
        {
            _engine = engine;
        }

        public Location Location { get; set; }
        public Direction Direction { get; set; }

        public void ExecuteCommands(IEnumerable<string> commands)
        {
            foreach (var command in commands)
            {
                ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(string command)
        {
            var result = _engine.Execute(command, Location, Direction);
            if (result.Success)
            {
                UpdateLocation(result.RobotLocation);
                UpdateDirection(result.Direction);
                PrintCommand(command);
            }
        }

        private void UpdateDirection(Direction direction)
        {
            Direction = direction;
        }

        private void UpdateLocation(Location location)
        {
            Location = location;
        }

        private void PrintCommand(string command)
        {
            Console.WriteLine(command);
            if (command == Command.Report)
            {
                Console.WriteLine($"Output: {Location.X},{Location.Y},{Direction}");
            }
        }
    }
}

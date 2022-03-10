using ToyRobot.Enums;

namespace ToyRobot.Core.Model
{
    public class Result
    {
        public Result(bool success, Location? location, Direction direction)
        {
            Success = success;
            RobotLocation = location;
            Direction = direction;
        }

        public bool Success { get; set; }
        public Location? RobotLocation { get; set; }
        public Direction Direction { get; set; }
    }
}

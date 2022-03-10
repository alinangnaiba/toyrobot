using ToyRobot.Core.Model;
using ToyRobot.Enums;

namespace ToyRobot.Core.Interface
{
    public interface IRobotEngine
    {
        Result Execute(string command, Location location, Direction direction);
    }
}

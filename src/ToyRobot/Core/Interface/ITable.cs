using ToyRobot.Core.Model;

namespace ToyRobot.Core.Interface
{
    public interface ITable
    {
        bool HasRobot { get; set; }
        bool IsValidLocation(Location location);
    }
}

namespace ToyRobot.Core.Interface
{
    public interface IRobot
    {
        void ExecuteCommands(IEnumerable<string> commands);
    }
}

namespace ToyRobot.Core.Interface
{
    public interface ICommandReader
    {
        string GetFilePath();
        IEnumerable<string> ReadCommands();
    }
}

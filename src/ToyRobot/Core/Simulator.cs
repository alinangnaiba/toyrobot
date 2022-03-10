using ToyRobot.Core.Interface;
using ToyRobot.Helper;

namespace ToyRobot.Core
{
    public class Simulator : ISimulator
    {
        private readonly ICommandReader _commandReader;
        private readonly Table _board;

        public Simulator(ICommandReader commandReader)
        {
            _commandReader = commandReader;
            _board = new Table(5, 5);
        }

        public void Run()
        {
            IEnumerable<string> commands;
            try
            {
                commands = _commandReader.ReadCommands();
                if (!commands.Any())
                    throw new ArgumentException("No command found.");

                var robotEngine = new RobotEngine(_board);
                var robot = new Robot(robotEngine);
                robot.ExecuteCommands(commands);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File cannot be found. Path: {_commandReader.GetFilePath()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

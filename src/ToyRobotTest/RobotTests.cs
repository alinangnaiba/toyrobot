using NUnit.Framework;
using System.Collections.Generic;
using ToyRobot.Core;
using ToyRobot.Enums;

namespace ToyRobotTest
{
    public class RobotTests
    {
        [Test]
        public void ExecuteCommands_ShouldExecuteCommandSequence_WhenRobotIsInTable()
        {
            var commands = new List<string> { "PLACE 2,3,WEST", "MOVE", "LEFT", "REPORT" };
            var table = new Table(5, 5);
            var engine = new RobotEngine(table);
            var robot = new Robot(engine);

            robot.ExecuteCommands(commands);

            Assert.AreEqual(robot.Direction, Direction.SOUTH);
            Assert.AreEqual(robot.Location.X, 1);
            Assert.AreEqual(robot.Location.Y, 3);
        }

        [Test]
        public void ExecuteCommands_ShouldIgnoreCommandSequence_WhenRobotIsNotInTable()
        {
            var commands = new List<string> { "MOVE", "LEFT", "REPORT" };
            var table = new Table(5, 5);
            var engine = new RobotEngine(table);
            var robot = new Robot(engine);

            robot.ExecuteCommands(commands);

            Assert.AreEqual(robot.Direction, Direction.NORTH);
            Assert.IsNull(robot.Location);
        }
    }
}

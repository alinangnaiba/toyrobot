using NUnit.Framework;
using ToyRobot.Core;
using ToyRobot.Core.Model;
using ToyRobot.Enums;

namespace ToyRobotTest
{
    public class RobotEngineTests
    {
        [Test]
        public void Execute_ShouldReturnSuccessResult_WhenPlaceCommandIsValid()
        {
            var command = "PLACE 1,2,WEST";
            Location location = new Location();
            Direction direction = Direction.NORTH;
            var table = new Table(5, 5);
            var engine = new RobotEngine(table);

            var result = engine.Execute(command, location, direction);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Direction, Direction.WEST);
            Assert.AreEqual(result.RobotLocation.X, 1);
            Assert.AreEqual(result.RobotLocation.Y, 2);
        }

        [Test]
        public void Execute_ShouldReturnSuccessResult_WhenMoveCommandIsValid()
        {
            var command = "MOVE";
            Location location = new Location { X = 3, Y = 2};
            Direction direction = Direction.NORTH;
            var table = new Table(5, 5);
            table.HasRobot = true;
            var engine = new RobotEngine(table);

            var result = engine.Execute(command, location, direction);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Direction, Direction.NORTH);
            Assert.AreEqual(result.RobotLocation.X, 3);
            Assert.AreEqual(result.RobotLocation.Y, 3);
        }

        [Test]
        public void Execute_ShouldReturnSuccessResult_WhenLeftCommandIsValid()
        {
            var command = "LEFT";
            Location location = new Location { X = 1, Y = 2 };
            Direction direction = Direction.NORTH;
            var table = new Table(5, 5);
            table.HasRobot = true;
            var engine = new RobotEngine(table);

            var result = engine.Execute(command, location, direction);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Direction, Direction.WEST);
            Assert.AreEqual(result.RobotLocation.X, 1);
            Assert.AreEqual(result.RobotLocation.Y, 2);
        }

        [Test]
        public void Execute_ShouldReturnSuccessResult_WhenRightCommandIsValid()
        {
            var command = "RIGHT";
            Location location = new Location { X = 3, Y = 3 };
            Direction direction = Direction.EAST;
            var table = new Table(5, 5);
            table.HasRobot = true;
            var engine = new RobotEngine(table);


            var result = engine.Execute(command, location, direction);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Direction, Direction.SOUTH);
            Assert.AreEqual(result.RobotLocation.X, 3);
            Assert.AreEqual(result.RobotLocation.Y, 3);
        }

        [Test]
        public void Execute_ShouldReturnSuccessResult_WhenReportCommandIsValid()
        {
            var command = "REPORT";
            Location location = new Location { X = 2, Y = 2 };
            Direction direction = Direction.SOUTH;
            var table = new Table(5, 5);
            table.HasRobot = true;
            var engine = new RobotEngine(table);


            var result = engine.Execute(command, location, direction);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(result.Direction, Direction.SOUTH);
            Assert.AreEqual(result.RobotLocation.X, 2);
            Assert.AreEqual(result.RobotLocation.Y, 2);
        }
        [Test]
        public void Execute_CommandShoudBeIgnored_WhenRobotFallsFromTableOnMove()
        {
            var command = "MOVE";
            Location location = new Location { X = 0, Y = 3 };
            Direction direction = Direction.WEST;
            var table = new Table(5, 5);
            var engine = new RobotEngine(table);
            table.HasRobot = true;
            var result = engine.Execute(command, location, direction);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Direction, Direction.WEST);
            Assert.AreEqual(result.RobotLocation.X, 0);
            Assert.AreEqual(result.RobotLocation.Y, 3);
        }

        [Test]
        public void Execute_CommandShoudBeIgnored_WhenInvalid()
        {
            var command = "M0VE";
            Location location = new Location { X = 3, Y = 3 };
            Direction direction = Direction.NORTH;
            var table = new Table(5, 5);
            var engine = new RobotEngine(table);
            table.HasRobot = true;
            var result = engine.Execute(command, location, direction);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Direction, Direction.NORTH);
            Assert.AreEqual(result.RobotLocation.X, 3);
            Assert.AreEqual(result.RobotLocation.Y, 3);
        }
    }
}
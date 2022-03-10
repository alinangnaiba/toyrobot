using ToyRobot.Core.Interface;
using ToyRobot.Core.Model;
using ToyRobot.Enums;
using ToyRobot.Helper;

namespace ToyRobot.Core
{
    public class RobotEngine : IRobotEngine
    {
        private readonly ITable _table;
        public RobotEngine(ITable board)
        {
            _table = board;
        }

        public Result Execute(string command, Location currentLocation, Direction currentDirection)
        {
            var parsedCommand = CommandParser.Parse(command);
            if (!CommandParser.IsValidCommand(parsedCommand))
                return new Result(false, currentLocation, currentDirection);

            Result result = parsedCommand switch
            {
                Command.Place => ExecutePlaceCommand(command, currentLocation, currentDirection),
                Command.Move => ExecuteMoveCommand(currentLocation, currentDirection),
                Command.Report => new Result(_table.HasRobot, currentLocation, currentDirection),
                _ => ExecuteChangeDirection(command, currentLocation, currentDirection),
            };
            return result;
        }

        private Result ExecutePlaceCommand(string command, Location? currentLocation, Direction currentDirection)
        {
            (var location, var direction) = CommandParser.GetStartLocationAndDirection(command);
            if (!_table.IsValidLocation(location))
                return new Result(false, currentLocation, currentDirection);

            _table.HasRobot = true;
            return new Result(true, location, direction);
        }

        private Result ExecuteMoveCommand(Location currentLocation, Direction currentDirection)
        {
            if (!_table.HasRobot) 
                return new Result(false, currentLocation, currentDirection);

            (var success, var newLocation) = currentDirection switch
            {
                Direction.NORTH => MoveOnYCoordinate(1, currentLocation),
                Direction.SOUTH => MoveOnYCoordinate(-1, currentLocation),
                Direction.EAST => MoveOnXCoordinate(1, currentLocation),
                _ => MoveOnXCoordinate(-1, currentLocation),
            };

            return new Result(success, newLocation, currentDirection);
        }

        private (bool success, Location newLocation) MoveOnYCoordinate(int value, Location currentLocation)
        {
            var newLocation = new Location
            {
                X = currentLocation.X,
                Y = currentLocation.Y + value
            };

            return Move(currentLocation, newLocation);
        }

        private (bool success, Location newLocation) MoveOnXCoordinate(int value, Location currentLocation)
        {
            var newLocation = new Location
            {
                X = currentLocation.X + value,
                Y = currentLocation.Y
            };

            return Move(currentLocation, newLocation);
        }

        private (bool success, Location newLocation) Move(Location currentLocation, Location newLocation)
        {
            if (_table.IsValidLocation(newLocation))
                return (true, newLocation);

            return (false, currentLocation);
        }

        private Result ExecuteChangeDirection(string command, Location currentLocation, Direction currentDirection)
        {
            if (!_table.HasRobot)
                return new Result(false, currentLocation, currentDirection);

            if (command == Command.Left)
                return new Result(true, currentLocation, Rotate(-1, currentDirection));

            return new Result(true, currentLocation, Rotate(1, currentDirection));
        }

        private static Direction Rotate(int value, Direction currentDirection)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            if (currentDirection + value < 0)
                return directions[directions.Length - 1];
            
            var index = ((int)currentDirection + value) % directions.Length;
            return directions[index];
        }
    }
}

using ToyRobot.Core.Interface;
using ToyRobot.Core.Model;

namespace ToyRobot.Core
{
    public class Table : ITable
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool HasRobot { get; set; }

        public Table(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public bool IsValidLocation(Location location)
        {
            if (location.X < 0 || location.Y < 0 ||
                location.X > Rows || location.Y > Columns)
                return false;

            return true;
        }
    }
}

using System.Drawing;

namespace TpGrilleSigne.Models
{
    public class GridNumber
    {
        // Properties
        public string StringerNumber { get; set; } = "";
        public int Number {
            get
            {
                return int.Parse(StringerNumber);
            }
        }
        public List<Point> NearestCoordinates { get; set; } = new List<Point>();

        public void AddNearestCoordinates(int x, int y)
        {
            if (!NearestCoordinates.Contains(new Point(x - 1, y - 1)))
            {
                NearestCoordinates.Add(new Point(x - 1, y - 1));
            }

            if (!NearestCoordinates.Contains(new Point(x - 1, y)))
            {
                NearestCoordinates.Add(new Point(x - 1, y));
            }

            if (!NearestCoordinates.Contains(new Point(x - 1, y + 1)))
            {
                NearestCoordinates.Add(new Point(x - 1, y + 1));
            }

            if (!NearestCoordinates.Contains(new Point(x, y - 1)))
            {
                NearestCoordinates.Add(new Point(x, y - 1));
            }

            if (!NearestCoordinates.Contains(new Point(x, y + 1)))
            {
                NearestCoordinates.Add(new Point(x, y + 1));
            }

            if (!NearestCoordinates.Contains(new Point(x + 1, y - 1)))
            {
                NearestCoordinates.Add(new Point(x + 1, y - 1));
            }

            if (!NearestCoordinates.Contains(new Point(x + 1, y)))
            {
                NearestCoordinates.Add(new Point(x + 1, y));
            }

            if (!NearestCoordinates.Contains(new Point(x + 1, y + 1)))
            {
                NearestCoordinates.Add(new Point(x + 1, y + 1));
            }

            
        }
    }
}
using System.Collections.Generic;

namespace Trackr.Api.Mappers
{
    /// <summary>
    /// A mapper class for converting a position to points.
    /// </summary>
    public class PointsMapper
    {
        private static Dictionary<int, int> _points = new Dictionary<int, int>
        {
            { 1, 25 },
            { 2, 18 },
            { 3, 15 },
            { 4, 12 },
            { 5, 10 },
            { 6, 8 },
            { 7, 6 },
            { 8, 4 },
            { 9, 2 },
            { 10, 1 },
        };

        /// <summary>
        /// Get the number of points that correlate to the position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The points.</returns>
        public static int GetPointsForPosition(int position)
        {
            // If the position is not a valid one (0 or higher then 10), return 0 points.
            if (!_points.ContainsKey(position))
            {
                return 0;
            }

            // Return the number of points correlated to the position.
            return _points[position];
        }
    }
}
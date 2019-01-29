using System.Collections.Generic;
using System.Linq;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ChampionshipMapper
    {
        /// <summary>
        /// Retrieve Championship standings from all race results.
        /// </summary>
        /// <param name="events">The events to retrieve race results from.</param>
        /// <returns>The standings.</returns>
        public static List<StandingEntity> RetrieveStandingsFromChampionship(List<EventEntity> events)
        {
            // Filter all the "Race"-sessions from the input.
            var raceSessions = events.SelectMany(r => r.Sessions).Where(s => s.SessionType == SessionType.Race).ToList();

            var standings = new List<StandingEntity>();

            // Loop through the results and count the points for all participants.
            for (int idx = 0; idx < raceSessions.Count; idx++)
            {
                var session = raceSessions[idx];

                for (int dix = 0; dix < session.Results.Count; dix++)
                {
                    var result = session.Results[dix];

                    // Calculate the points based on the position.
                    var points = PointsMapper.GetPointsForPosition(result.Position);

                    var driverIndex = standings.FindIndex(s => s.Name == result.Driver);

                    // Check wether the current driver already exists in the standings.
                    if (driverIndex == -1)
                    {
                        // The driver does not exist yet, add it.
                        standings.Add(new StandingEntity
                        {
                            Name = result.Driver,
                            Points = points
                        });
                    }
                    else
                    {
                        // Add the points.
                        standings[driverIndex].Points = standings[driverIndex].Points + points;
                    }
                }
            }

            // Order the standings by the highest number of points.
            standings = standings.OrderBy(s => s.Points).ToList();

            // Loop through the standings and set the position accordingly.
            for (var idx = 0; idx < standings.Count; idx++)
            {
                standings[idx].Position = idx + 1;
            }

            // Return the standings.
            return standings;
        }
    }
}
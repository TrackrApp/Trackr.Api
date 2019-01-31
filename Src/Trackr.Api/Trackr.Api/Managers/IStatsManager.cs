using Trackr.Api.ViewModels;

namespace Trackr.Api.Managers
{
    /// <summary>
    /// The interface gathering all stats related.
    /// </summary>
    public interface IStatsManager
    {
        /// <summary>
        /// Get the stats.
        /// </summary>
        /// <returns></returns>
        StatsViewModel GetStats();
    }
}
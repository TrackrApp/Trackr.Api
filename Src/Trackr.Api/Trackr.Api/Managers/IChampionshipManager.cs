using System.Collections.Generic;
using System.Threading.Tasks;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Managers
{
    /// <summary>
    /// Manager interface for anything Championship related.
    /// </summary>
    public interface IChampionshipManager
    {
        /// <summary>
        /// Get all Championships.
        /// </summary>
        /// <returns>A collection of Championships.</returns>
        List<ChampionshipEntity> GetAll();

        /// <summary>
        /// Find a Championship based on a given query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A collection of matches, or empty if no match was found.</returns>
        List<ChampionshipEntity> Find(string query);

        /// <summary>
        /// Get a specific Championship.
        /// </summary>
        /// <param name="id">The id of the requested Championship.</param>
        /// <returns></returns>
        ChampionshipEntity Get(int id);

        /// <summary>
        /// Add the given Championship entity to storage.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns></returns>
        Task AddAsync(ChampionshipEntity entity);
    }
}
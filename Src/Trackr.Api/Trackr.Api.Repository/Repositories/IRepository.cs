using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trackr.Api.Model.Repositories
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all of a given type.
        /// </summary>
        /// <returns>A collection of results.</returns>
        List<T> GetAll();

        /// <summary>
        /// Get a given type based on an unique identifier.
        /// </summary>
        /// <param name="id">The unique id of the type.</param>
        /// <returns>The type, if found. Else null.</returns>
        T Get(int id);

        /// <summary>
        /// Find 0..* of a given type based on the given conditions.
        /// </summary>
        /// <param name="query">The condition which must be met.</param>
        /// <returns>A collection of results, or empty if no condition is met.</returns>
        List<T> Find(string query);

        /// <summary>
        /// Add an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The id of the newly created entity.</returns>
        Task<int> AddAsync(T entity);
    }
}
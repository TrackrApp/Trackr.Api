using System.Collections.Generic;
using System.Linq;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Helpers
{
    /// <summary>
    /// Result State/Entity mapper.
    /// </summary>
    public static class ResultMapper
    {
        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="ResultEntity"/> to a collection of <see cref="ResultState"/>.
        /// </summary>
        /// <param name="entities">The collection of <see cref="ResultEntity"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<ResultState> ToState(this List<ResultEntity> entities)
        {
            // If the input is null or empty, return an empty list.
            if (!entities?.Any() == true)
            {
                return new List<ResultState>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<ResultState>();

            for (var idx = 0; idx < entities.Count; idx++)
            {
                 result.Add(entities[idx].ToState());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="ResultEntity"/> to a <see cref="ResultState"/>.
        /// </summary>
        /// <param name="entity">The <see cref="ResultEntity"/>.</param>
        /// <returns>The converted entity.</returns>
        public static ResultState ToState(this ResultEntity entity)
        {
            return new ResultState
            {
                Id = entity.Id,
                Position = entity.Position,
                Driver = entity.Driver,
                Time = entity.Time,
                Difference = entity.Difference,
                Laps = entity.Laps
            };
        }

        #endregion Entity to State.


        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="ResultState"/> to a collection of <see cref="ResultEntity"/>.
        /// </summary>
        /// <param name="states">The collection of <see cref="ResultState"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<ResultEntity> ToEntity(this ICollection<ResultState> states)
        {
            // If the input is null or empty, return an empty list.
            if (!states?.Any() == true)
            {
                return new List<ResultEntity>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<ResultEntity>();

            for (var idx = 0; idx < states.Count; idx++)
            {
                result.Add(states.ElementAt(idx).ToEntity());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="ResultState"/> to a <see cref="ResultEntity"/>.
        /// </summary>
        /// <param name="state">The <see cref="ResultState"/>.</param>
        /// <returns>The converted entity.</returns>
        public static ResultEntity ToEntity(this ResultState state)
        {
            return new ResultEntity
            {
                Id = state.Id,
                Position = state.Position,
                Driver = state.Driver,
                Time = state.Time,
                Difference = state.Difference,
                Laps = state.Laps
            };
        }

        #endregion State to Entity.
    }
}
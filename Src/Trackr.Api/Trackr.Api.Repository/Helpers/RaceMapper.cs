using System.Collections.Generic;
using System.Linq;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Helpers
{
    /// <summary>
    /// Race State/Entity mapper.
    /// </summary>
    public static class RaceMapper
    {
        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="RaceEntity"/> to a collection of <see cref="RaceState"/>.
        /// </summary>
        /// <param name="entities">The collection of <see cref="RaceEntity"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<RaceState> ToState(this List<RaceEntity> entities)
        {
            // If the input is null or empty, return an empty list.
            if (!entities?.Any() == true)
            {
                return new List<RaceState>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<RaceState>();

            for (var idx = 0; idx < entities.Count; idx++)
            {
                 result.Add(entities[idx].ToState());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="RaceEntity"/> to a <see cref="RaceState"/>.
        /// </summary>
        /// <param name="entity">The <see cref="RaceEntity"/>.</param>
        /// <returns>The converted entity.</returns>
        public static RaceState ToState(this RaceEntity entity)
        {
            return new RaceState
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location,
                Url = entity.Url,
                DateFrom = entity.DateFrom,
                DateTo = entity.DateTo,
                Sessions = entity.Sessions.ToState()
            };
        }

        #endregion Entity to State.


        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="RaceState"/> to a collection of <see cref="RaceEntity"/>.
        /// </summary>
        /// <param name="states">The collection of <see cref="RaceState"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<RaceEntity> ToState(this List<RaceState> states)
        {
            // If the input is null or empty, return an empty list.
            if (!states?.Any() == true)
            {
                return new List<RaceEntity>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<RaceEntity>();

            for (var idx = 0; idx < states.Count; idx++)
            {
                result.Add(states[idx].ToEntity());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="RaceState"/> to a <see cref="RaceEntity"/>.
        /// </summary>
        /// <param name="state">The <see cref="RaceState"/>.</param>
        /// <returns>The converted entity.</returns>
        public static RaceEntity ToEntity(this RaceState state)
        {
            return new RaceEntity
            {
                Id = state.Id,
                Name = state.Name,
                Location = state.Location,
                Url = state.Url,
                DateFrom = state.DateFrom,
                DateTo = state.DateTo,
                Sessions = state.Sessions.ToEntity()
            };
        }

        #endregion State to Entity.
    }
}
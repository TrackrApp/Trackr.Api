using System.Collections.Generic;
using System.Linq;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Helpers
{
    /// <summary>
    /// Championship State/Entity mapper.
    /// </summary>
    public static class ChampionshipMapper
    {
        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="ChampionshipEntity"/> to a collection of <see cref="ChampionshipState"/>.
        /// </summary>
        /// <param name="entities">The collection of <see cref="ChampionshipEntity"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<ChampionshipState> ToState(this List<ChampionshipEntity> entities)
        {
            // If the input is null or empty, return an empty list.
            if (!entities?.Any() == true)
            {
                return new List<ChampionshipState>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<ChampionshipState>();

            for (var idx = 0; idx < entities.Count; idx++)
            {
                result.Add(entities[idx].ToState());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="ChampionshipEntity"/> to a <see cref="ChampionshipState"/>.
        /// </summary>
        /// <param name="entity">The <see cref="ChampionshipEntity"/>.</param>
        /// <returns>The converted entity.</returns>
        public static ChampionshipState ToState(this ChampionshipEntity entity)
        {
            return new ChampionshipState
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ChampionshipImageUrl = entity.ChampionshipImageUrl,
                Events = entity.Events.ToState()
            };
        }

        #endregion Entity to State.

        #region State to Entity.

        /// <summary>
        /// Convert a collection of <see cref="ChampionshipState"/> to a collection of <see cref="ChampionshipEntity"/>.
        /// </summary>
        /// <param name="states">The collection of <see cref="ChampionshipState"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<ChampionshipEntity> ToEntity(this ICollection<ChampionshipState> states)
        {
            // If the input is null or empty, return an empty list.
            if (!states?.Any() == true)
            {
                return new List<ChampionshipEntity>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<ChampionshipEntity>();

            for (var idx = 0; idx < states.Count; idx++)
            {
                result.Add(states.ElementAt(idx).ToEntity());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="ChampionshipState"/> to a <see cref="ChampionshipEntity"/>.
        /// </summary>
        /// <param name="state">The <see cref="ChampionshipState"/>.</param>
        /// <returns>The converted entity.</returns>
        public static ChampionshipEntity ToEntity(this ChampionshipState state)
        {
            return new ChampionshipEntity
            {
                Id = state.Id,
                Name = state.Name,
                Description = state.Description,
                ChampionshipImageUrl = state.ChampionshipImageUrl,
                Events = state.Events.ToEntity()
            };
        }

        #endregion Entity to State.
    }
}
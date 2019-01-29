using System.Collections.Generic;
using System.Linq;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Helpers
{
    /// <summary>
    /// Session State/Entity mapper.
    /// </summary>
    public static class SessionMapper
    {
        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="SessionEntity"/> to a collection of <see cref="SessionState"/>.
        /// </summary>
        /// <param name="entities">The collection of <see cref="SessionState"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<SessionState> ToState(this List<SessionEntity> entities)
        {
            // If the input is null or empty, return an empty list.
            if (!entities?.Any() == true)
            {
                return new List<SessionState>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<SessionState>();

            for (var idx = 0; idx < entities.Count; idx++)
            {
                result.Add(entities[idx].ToState());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="SessionEntity"/> to a <see cref="SessionState"/>.
        /// </summary>
        /// <param name="entity">The <see cref="SessionEntity"/>.</param>
        /// <returns>The converted entity.</returns>
        public static SessionState ToState(this SessionEntity entity)
        {
            return new SessionState
            {
                Id = entity.Id,
                Name = entity.Name,
                SessionType = entity.SessionType,
                Results = entity.Results.ToState()
            };
        }

        #endregion Entity to State.

        #region State to Entity.

        /// <summary>
        /// Convert a collection of <see cref="SessionState"/> to a collection of <see cref="SessionEntity"/>.
        /// </summary>
        /// <param name="states">The collection of <see cref="SessionState"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<SessionEntity> ToEntity(this ICollection<SessionState> states)
        {
            // If the input is null or empty, return an empty list.
            if (!states?.Any() == true)
            {
                return new List<SessionEntity>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<SessionEntity>();

            for (var idx = 0; idx < states.Count; idx++)
            {
                result.Add(states.ElementAt(idx).ToEntity());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="SessionState"/> to a <see cref="SessionEntity"/>.
        /// </summary>
        /// <param name="state">The <see cref="SessionState"/>.</param>
        /// <returns>The converted entity.</returns>
        public static SessionEntity ToEntity(this SessionState state)
        {
            return new SessionEntity
            {
                Id = state.Id,
                Name = state.Name,
                SessionType = state.SessionType,
                Results = state.Results.ToEntity()
            };
        }

        #endregion State to Entity.
    }
}
using System.Collections.Generic;
using System.Linq;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Helpers
{
    /// <summary>
    /// Event State/Entity mapper.
    /// </summary>
    public static class EventMapper
    {
        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="EventEntity"/> to a collection of <see cref="EventState"/>.
        /// </summary>
        /// <param name="entities">The collection of <see cref="EventEntity"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<EventState> ToState(this List<EventEntity> entities)
        {
            // If the input is null or empty, return an empty list.
            if (!entities?.Any() == true)
            {
                return new List<EventState>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<EventState>();

            for (var idx = 0; idx < entities.Count; idx++)
            {
                 result.Add(entities[idx].ToState());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="EventEntity"/> to a <see cref="EventState"/>.
        /// </summary>
        /// <param name="entity">The <see cref="EventEntity"/>.</param>
        /// <returns>The converted entity.</returns>
        public static EventState ToState(this EventEntity entity)
        {
            return new EventState
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location,
                Address = entity.Address,
                Url = entity.Url,
                HeaderImageUrl = entity.HeaderImageUrl,
                HeaderPosition = entity.HeaderPosition,
                EventLogoUrl = entity.EventLogoUrl,
                DateFrom = entity.DateFrom,
                DateTo = entity.DateTo,
                Sessions = entity.Sessions.ToState()
            };
        }

        #endregion Entity to State.

        #region Entity to State.

        /// <summary>
        /// Convert a collection of <see cref="EventState"/> to a collection of <see cref="EventEntity"/>.
        /// </summary>
        /// <param name="states">The collection of <see cref="EventState"/>.</param>
        /// <returns>The converted entities.</returns>
        public static List<EventEntity> ToEntity(this ICollection<EventState> states)
        {
            // If the input is null or empty, return an empty list.
            if (!states?.Any() == true)
            {
                return new List<EventEntity>();
            }

            // The collection is valid. Create a new result and convert the contents of the collection.
            var result = new List<EventEntity>();

            for (var idx = 0; idx < states.Count; idx++)
            {
                result.Add(states.ElementAt(idx).ToEntity());
            }

            return result;
        }

        /// <summary>
        /// Convert a <see cref="EventState"/> to a <see cref="EventEntity"/>.
        /// </summary>
        /// <param name="state">The <see cref="EventState"/>.</param>
        /// <returns>The converted entity.</returns>
        public static EventEntity ToEntity(this EventState state)
        {
            return new EventEntity
            {
                Id = state.Id,
                Name = state.Name,
                Location = state.Location,
                Address = state.Address,                
                Url = state.Url,
                HeaderImageUrl = state.HeaderImageUrl,
                HeaderPosition = state.HeaderPosition,
                EventLogoUrl = state.EventLogoUrl,
                DateFrom = state.DateFrom,
                DateTo = state.DateTo,
                Sessions = state.Sessions.ToEntity()
            };
        }

        #endregion State to Entity.
    }
}
using System.Collections.Generic;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.ViewModels
{
    /// <summary>
    /// The ViewModel containing data for the Championship Overview page.
    /// </summary>
    public class ChampionshipOverviewViewModel
    {
        /// <summary>
        /// The id of the Championship.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Championship.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the Championship.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the image associated with the Championship.
        /// </summary>
        public string ChampionshipImageUrl { get; set; }

        /// <summary>
        /// The last Event results.
        /// </summary>
        public EventEntity LastResult { get; set; }

        /// <summary>
        /// The standings for the Championship.
        /// </summary>
        public List<StandingEntity> Standings { get; set; } = new List<StandingEntity>();
    }
}
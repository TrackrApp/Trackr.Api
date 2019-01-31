using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trackr.Api.Model.Storage
{
    [Table("Event", Schema = "Trackr")]
    public class EventState
    {
        public EventState()
        {
            Sessions = new List<SessionState>();
        }

        /// <summary>
        /// Is automatically assigned to be PK.
        /// </summary>
        public int Id { get; set; }

        public int ChampionshipId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string Url { get; set; }

        public byte[] HeaderImage { get; set; }

        public double? HeaderPosition { get; set; }

        public byte[] EventLogo { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset? DateTo { get; set; }

        public virtual ICollection<SessionState> Sessions { get; set; }

        [ForeignKey("ChampionshipId")]
        public virtual ChampionshipState Championship { get; set; }
    }
}
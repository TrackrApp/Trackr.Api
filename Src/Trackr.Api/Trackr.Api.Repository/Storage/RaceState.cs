using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trackr.Api.Model.Storage
{
    [Table("Race", Schema = "Trackr")]
    public class RaceState
    {
        public RaceState()
        {
            Sessions = new List<SessionState>();
        }

        /// <summary>
        /// Is automatically assigned to be PK.
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Url { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset? DateTo { get; set; }

        public List<SessionState> Sessions { get; set; }
    }
}
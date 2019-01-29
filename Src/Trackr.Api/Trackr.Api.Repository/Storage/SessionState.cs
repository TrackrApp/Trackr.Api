using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Storage
{
    [Table("Session", Schema = "Trackr")]
    public class SessionState
    {
        public SessionState()
        {
            Results = new List<ResultState>();
        }

        /// <summary>
        /// Is automatically assigned to be PK.
        /// </summary>
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Name { get; set; }

        public SessionType SessionType { get; set; }

        public virtual ICollection<ResultState> Results { get; set; }

        [ForeignKey("EventId")]
        public virtual EventState Event { get; set; }
    }
}
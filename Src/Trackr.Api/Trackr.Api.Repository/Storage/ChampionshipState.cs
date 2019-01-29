using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trackr.Api.Model.Storage
{
    [Table("Championship", Schema = "Trackr")]
    public class ChampionshipState
    {
        public ChampionshipState()
        {
            Events = new List<EventState>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<EventState> Events { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trackr.Api.Model.Storage
{
    [Table("Championship", Schema = "Trackr")]
    public class ChampionshipState
    {
        public ChampionshipState()
        {
            Races = new List<RaceState>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<RaceState> Races { get; set; }
    }
}
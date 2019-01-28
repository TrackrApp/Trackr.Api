using System.Collections.Generic;

namespace Trackr.Api.Shared.Domain
{
    public class ChampionshipEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<RaceEntity> Races { get; set; } = new List<RaceEntity>();
    }
}
using System.Collections.Generic;

namespace Trackr.Api.Shared.Domain
{
    public class ChampionshipEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ChampionshipImageUrl { get; set; }

        public List<EventEntity> Events { get; set; } = new List<EventEntity>();
    }
}
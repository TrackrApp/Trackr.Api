using System;
using System.Collections.Generic;

namespace Trackr.Api.Shared.Domain
{
    public class EventEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Url { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset? DateTo { get; set; }

        public List<SessionEntity> Sessions { get; set; } = new List<SessionEntity>();
    }
}
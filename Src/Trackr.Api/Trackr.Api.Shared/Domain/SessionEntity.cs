using System.Collections.Generic;

namespace Trackr.Api.Shared.Domain
{
    public class SessionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SessionType SessionType { get; set; }

        public List<ResultEntity> Results { get; set; } = new List<ResultEntity>();
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Trackr.Api.Shared.Domain
{
    public class SessionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SessionType SessionType { get; set; }

        public List<ResultEntity> Results { get; set; } = new List<ResultEntity>();
    }
}
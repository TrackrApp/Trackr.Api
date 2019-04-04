using Newtonsoft.Json;

namespace Trackr.Api.Shared.Domain
{
    public class StandingEntity
    {
        public int Position { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        /// <summary>
        /// Number indicating how many races it took the driver to accumulate the amount of <see cref="Points"/>.
        /// </summary>
        /// <remarks>
        /// Ignore this property while serializing to JSON when sending to the client.
        /// </remarks>
        [JsonIgnore]
public int NumberOfRaces { get; set; }

        public string Changes { get; set; }
    }
}
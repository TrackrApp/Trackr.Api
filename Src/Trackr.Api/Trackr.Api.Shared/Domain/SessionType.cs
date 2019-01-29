using System.Runtime.Serialization;

namespace Trackr.Api.Shared.Domain
{
    public enum SessionType
    {
        [EnumMember(Value = "T")]
        Training,

        [EnumMember(Value = "Q")]
        Qualification,

        [EnumMember(Value ="R")]
        Race
    }
}
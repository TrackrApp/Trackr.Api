using System.Runtime.Serialization;

namespace Trackr.Api.Shared.Domain
{
    public enum SessionType
    {
        [EnumMember(Value = "Training")]
        Training,

        [EnumMember(Value = "Qualifying")]
        Qualification,

        [EnumMember(Value ="Race")]
        Race
    }
}
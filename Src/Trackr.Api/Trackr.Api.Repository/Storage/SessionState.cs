using System.ComponentModel.DataAnnotations.Schema;

namespace Trackr.Api.Model.Storage
{
    [Table("Session", Schema = "Trackr")]
    public class SessionState
    {
        /// <summary>
        /// Is automatically assigned to be PK.
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
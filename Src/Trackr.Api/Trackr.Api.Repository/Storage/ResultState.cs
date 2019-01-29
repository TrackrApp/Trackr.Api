using System.ComponentModel.DataAnnotations.Schema;

namespace Trackr.Api.Model.Storage
{
    [Table("Result", Schema = "Trackr")]
    public class ResultState
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int Position { get; set; }

        public string Driver { get; set; }

        public string Time { get; set; }

        public string Difference { get; set; }

        public int Laps { get; set; }

        [ForeignKey("SessionId")]
        public virtual SessionState Session { get; set; }
    }
}
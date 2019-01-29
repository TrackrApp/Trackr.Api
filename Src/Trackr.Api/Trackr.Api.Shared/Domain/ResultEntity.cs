namespace Trackr.Api.Shared.Domain
{
    public class ResultEntity
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public string Driver { get; set; }

        public string Time { get; set; }

        public string Difference { get; set; }

        public int Laps { get; set; }
    }
}
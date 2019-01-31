namespace Trackr.Api.ViewModels
{
    /// <summary>
    /// The view model containing site stats data.
    /// </summary>
    public class StatsViewModel
    {
        /// <summary>
        /// The number of championships in the database.
        /// </summary>
        public int ChampionshipCount { get; set; }

        /// <summary>
        /// The number of drivers in the database.
        /// </summary>
        public int DriverCount { get; set; }

        /// <summary>
        /// The number of races in the database.
        /// </summary>
        public int EventCount { get; set; }

        /// <summary>
        /// The number of sessions in the database.
        /// </summary>
        public int SessionCount { get; set; }
    }
}
using Autofac;
using Trackr.Api.Controllers.Championship;
using Trackr.Api.Managers;
using Trackr.Api.Model.Repositories;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="ContainerBuilder"/>.
    /// </summary>
    public static class AutofacExtensions
    {
        /// <summary>
        /// Add Autofac modules to <see cref="ContainerBuilder"/>.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterModules(this ContainerBuilder builder)
        {
            // Register the database.
            builder.RegisterType<TrackrApiDbContext>();

            // Register the repositories.
            builder.RegisterType<ChampionshipRepository>()
                .As<IRepository<ChampionshipEntity>>();

            // Register the managers.
            builder.RegisterType<ChampionshipManager>()
                .As<IChampionshipManager>();

            // Register the controllers.
            builder.RegisterType<ChampionshipV1Controller>().PropertiesAutowired();
        }
    }
}
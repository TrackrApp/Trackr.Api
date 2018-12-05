using Autofac;
using Trackr.Api.Controllers.Championship;

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
            // Register the controllers.
            builder.RegisterType<ChampionshipV1Controller>().PropertiesAutowired();
        }
    }
}
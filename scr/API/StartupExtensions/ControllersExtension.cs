using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CTG.TRSS.API.StartupExtensions
{
    /// <summary>
    /// API Controllers Startup Extension
    /// </summary>
    public static class ControllersExtension
    {
        /// <summary>
        /// Startup Add Config for Controllers
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddControllersConfig(this IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.Conventions.Add(new ActionHidingConvention());
            })
            .AddNewtonsoftJson();

        }

        /// <summary>
        /// Startup Use Config for Controllers
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseControllersConfig(this IApplicationBuilder app)
        {

        }

    }
}

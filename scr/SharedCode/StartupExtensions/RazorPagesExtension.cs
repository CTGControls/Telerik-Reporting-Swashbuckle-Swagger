using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTG.TRSS.SharedCode.StartupExtensions
{
    /// <summary>
    /// UI_Internal RazorPages Extension
    /// </summary>
    public static class RazorPagesExtension
    {
        /// <summary>
        /// Add RazorPages Config
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddRazorPagesConfig(this IServiceCollection services)
        {

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
                });
        }

        /// <summary>
        /// Use RazorPagesConfig
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseRazorPagesConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages()
                    .RequireCors("CorsPolicy");
            });
        }

    }
}

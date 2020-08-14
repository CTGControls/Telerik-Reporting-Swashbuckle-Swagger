using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CTG.TRSS.SharedCode.StartupExtensions
{
    public static class CorsConfigurationExtension
    {
        /// <summary>
        /// Startup Add Config for CORS
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(CorsPolicy());
                options.AddPolicy("CorsPolicy", CorsPolicy());

            });
        }

        /// <summary>
        /// Startup Use Config for CORS
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder> CorsPolicy()
        {
            return new System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder>(
                builder => builder
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyOrigin()
                    //.WithOrigins("https://*.srihash.org", "http://*.srihash.org", "https://*.ctgcontrols.com", "https://*.flamemetals.com", "https://*.CTGFFM.com")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
                    );

        }

    }
}

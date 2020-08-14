using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CTG.TRSS.SharedCode.StartupExtensions
{
    /// <summary>
    /// API HttpsRedirection Startup Extension
    /// </summary>
    public static class HttpsRedirectionExtension
    {
        /// <summary>
        /// Startup Add Config for HttpsRedirection
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddHttpsRedirectionConfig(this IServiceCollection services)
        {

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 443;
            });

        }

        /// <summary>
        /// Startup Use Config for HttpsRedirection
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseHttpsRedirectionConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
        }

    }
}

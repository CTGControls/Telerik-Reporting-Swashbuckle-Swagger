using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;

namespace CTG.TRSS.API.StartupExtensions
{
    /// <summary>
    /// Reports Startup Extension
    /// </summary>
    public static class ReportTelerikExtension
    {
        /// <summary>
        /// Startup Add Config for Controllers
        /// </summary>
        /// <param name="services"></param>
        public static void AddReportTelerikConfig(this IServiceCollection services)
        {

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });



            services.TryAddSingleton<IReportServiceConfiguration>(
                sp => new ReportServiceConfiguration
                {

                    //Assembly:  Telerik.Reporting.Cache.Database (in Telerik.Reporting.Cache.Database.dll)
                    //Storage = new Telerik.Reporting.Cache.Database.DatabaseStorage("test","ConnectionString")

                    HostAppId = "ReportTelerik",
                    Storage = new FileStorage(),
                    ReportSourceResolver = new UriReportSourceResolver(
                        System.IO.Path.Combine(
                            sp.GetService<IWebHostEnvironment>().ContentRootPath,
                            "Reports/telerik")
                        )
                });

            // Configure dependencies for ReportDesignerServiceConfiguration.

            services.TryAddSingleton<IReportDesignerServiceConfiguration>(sp => new ReportDesignerServiceConfiguration
            {
                DefinitionStorage = new FileDefinitionStorage(
                    System.IO.Path.Combine(
                        sp.GetService<IWebHostEnvironment>().ContentRootPath, 
                        "Reports/telerik")
                    ),
                SettingsStorage = new FileSettingsStorage(
                    System.IO.Path.Combine(
                            sp.GetService<IWebHostEnvironment>().ContentRootPath,
                            "Reports/telerik")
                    )
            });

            services.TryAddScoped<IDefinitionStorage>(sp => 
                new FileDefinitionStorage(
                    System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath,
                            "Reports/telerik")));
            services.TryAddScoped<IReportDesignerServiceConfiguration>(sp => 
                new ReportDesignerServiceConfiguration 
                { 
                    DefinitionStorage = sp.GetRequiredService<IDefinitionStorage>() 
                });

        }

        /// <summary>
        /// Startup Use Config for Controllers
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseReportTelerikConfig(this IApplicationBuilder app)
        {

        }

    }
}

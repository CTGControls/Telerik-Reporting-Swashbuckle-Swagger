using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTG.TRSS.SharedCode.StartupExtensions;
using CTG.TRSS.API.StartupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CTG.TRSS.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsConfig();
            services.AddReportTelerikConfig();
            services.AddControllersConfig();
            services.AddHttpsRedirectionConfig();
            services.AddSwaggerGenConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirectionConfig();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCorsConfig();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireCors("CorsPolicy");
            });
        }
    }
}

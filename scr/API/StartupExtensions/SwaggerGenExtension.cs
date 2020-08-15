using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CTG.TRSS.API.StartupExtensions
{
    /// <summary>
    /// API SwaggerGen Startup Extension
    /// </summary>
    public static class SwaggerGenExtension
    {
        /// <summary>
        /// Startup Add Config for SwaggerGen
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="Configuration">IConfiguration</param>
        public static void AddSwaggerGenConfig(this IServiceCollection services) {

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.FullName);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FFM",
                    Version = "v1",
                    Description = "Heat Treat Management",
                    //TermsOfService = new Uri("None"),
                    Contact = new OpenApiContact
                    {
                        Name = "CTGControls.com",
                        Email = "chris@ctgcontrols.com",
                        Url = new Uri("https://www.ctgcontrols.com")
                    }                 
                });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    //OpenIdConnectUrl = new System.Uri(Configuration.GetIDPServerUrl() + "/.well-known/openid-configuration"),}
                }); ;

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { "ctgffm_api" }
                    }
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "api.xml");
                c.IncludeXmlComments(filePath);
                c.EnableAnnotations();
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        /// <summary>
        /// Startup Use Config for SwaggerGen
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseSwaggerGenConfig(this IApplicationBuilder app)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FFM API V1");
                //c.RoutePrefix = string.Empty;
                c.OAuthClientId("pkce_code_client");
                c.OAuthAppName("Code Client Using PKCE"); // presentation purposes only
                //c.OAuthClientId("ctgffm");
                //c.OAuthAppName("CTG Factory Floor Management"); // presentation purposes only
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
               
            });
        }

    }

    public class ActionHidingConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            // Replace with any logic you want
            if (action.Controller.ControllerName.Contains("reportsTelerikDesignerController")) 
            {
                action.ApiExplorer.IsVisible = false;
            }
        }
    }
}

# Telerik-Reporting-Swashbuckle-Swagger
> :warning: 
> **Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware[1]**
> An unhandled exception has occurred while executing the request.
> System.NotSupportedException: 
> Conflicting method/path combination "GET api/ReportDesignerControllerBase"for actions - Telerik.WebReportDesigner.Services.Controllers.ReportDesignerControllerBase.GetDesignerResource (Telerik.WebReportDesigner.Services),Telerik.WebReportDesigner.Services.Controllers.ReportDesignerControllerBase.GetResource (Telerik.WebReportDesigner.Services). 
> Actions require a unique method/path combination for Swagger/OpenAPI 3.0. 

> Use ConflictingActionsResolver as a workaround

> at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GenerateOperations(IEnumerable`1 apiDescriptions, SchemaRepository schemaRepository)
> at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GeneratePaths(IEnumerable`1 apiDescriptions, SchemaRepository schemaRepository)
> at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GetSwagger(String documentName, String host, String basePath)
> at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
> at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)

![Alt text](img/SwaggerGenExtension002.png?raw=true "Title")
# Telerik Reporting Swashbuckle Swagger

**This is an example to help Progress Telerik diagnose why the report designer is not compatible with [Swashbuckles'](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) implementation of swagger.**
 

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

### To generate the error you must enable to designer the be added to swagger. Open API => StartupExtensions => SwaggerGenExtension

Change line 74 from 

```csharp
if (action.Controller.ControllerName.Contains("Designer")) 
```
![No Error](img/SwaggerGenExtension002.png?raw=true "NoError")

to

```csharp
if (action.Controller.ControllerName.Contains("xDesigner")) 
```

![Error](img/SwaggerGenExtension003.png?raw=true "Error")
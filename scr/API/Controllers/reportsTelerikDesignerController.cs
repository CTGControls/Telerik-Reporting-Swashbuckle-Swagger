using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;
using Telerik.WebReportDesigner.Services.Controllers;

namespace API.Controllers
{
    /// <summary>
    /// Telerik report designer controller
    /// </summary>
    [Route("API/[controller]")]
    [ApiController]
    public class reportsTelerikDesignerController : ReportDesignerControllerBase
    {
        /// <summary>
        /// Telerik report designer controller
        /// </summary>
        /// <param name="reportDesignerServiceConfiguration"></param>
        /// <param name="reportServiceConfiguration"></param>
        public reportsTelerikDesignerController(IReportDesignerServiceConfiguration reportDesignerServiceConfiguration, IReportServiceConfiguration reportServiceConfiguration)
            : base(reportDesignerServiceConfiguration, reportServiceConfiguration)
        {
        }
    }
}

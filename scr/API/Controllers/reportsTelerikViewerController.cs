using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace CTG.TRSS.API.Controllers
{
    /// <summary>
    /// Routes Controller
    /// </summary>
    [Route("API/[controller]")]
    [ApiController]
    public class reportsTelerikViewerController : ReportsControllerBase
    {
        /// <summary>
        /// returns a intractive 
        /// </summary>
        /// <param name="reportServiceConfiguration"></param>
        public reportsTelerikViewerController(IReportServiceConfiguration reportServiceConfiguration)
            : base(reportServiceConfiguration)
        {
        }
    }
}

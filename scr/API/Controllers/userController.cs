using CTG.TRSS.SharedCode.APIModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace CTG.TRSS.API.Controllers
{
    /// <summary>
    /// Telerik report designer controller
    /// </summary>
    [Route("API/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        // IHostingEnvironment used with sample to get the application data from wwwroot.
        private IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        private string _userDataBase;


        public userController(IWebHostEnvironment hostingEnvironment,ILogger<userController> logger)

        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _userDataBase = Path.Combine(_hostingEnvironment.ContentRootPath, "Data/AppUsers.json");
        }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns>APIModels.addresses.parentDto</returns>
        /// <response code="200">Returns a list of users.</response>
        /// <response code="404">No User found.</response>
        [HttpGet("GetUsers", Name = "GetAddress")]
        [ProducesResponseType(typeof(List<AppUser>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {

            List<AppUser> appUser = new List<AppUser>();

            using (FileStream fs = System.IO.File.OpenRead(_userDataBase))
            {
                try
                {
                    appUser = await JsonSerializer.DeserializeAsync<List<AppUser>>(fs);
                }
                catch(Exception e)
                {
                    _logger.LogError(e.Message);
                }

            }

            return appUser;
        }

        /// <summary>
        /// Creates a new Address
        /// </summary>
        /// <param name="appUser">User Populate Dto</param>
        /// <returns>APIModels.addresses.parentDto</returns>
        /// <response code="201">If the user was created.</response>
        /// <response code="400">If the model is not formatted correctly.</response>
        [HttpPost(Name = "PostUser")]
        [ProducesResponseType(typeof(AppUser), 201)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<IActionResult> PostUser([FromBody] AppUser appUser)
        {
            List<AppUser> appUsers = new List<AppUser>();
            using (FileStream fs = System.IO.File.OpenRead(_userDataBase))
            {
                try
                {
                    appUsers = await JsonSerializer.DeserializeAsync<List<AppUser>>(fs);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }

            }
            appUser.Id = Guid.NewGuid();
            appUsers.Add(appUser);


            using (FileStream fs = System.IO.File.OpenWrite(_userDataBase))
            {
                await JsonSerializer.SerializeAsync(fs, appUsers);
            }

            return Created("", appUsers);

        }
    }
}

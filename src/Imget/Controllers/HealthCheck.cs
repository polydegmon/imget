using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Imget.Models;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
/// </remarks>
namespace Imget.Controllers
{
    [Route("")] // Web Root Url
    [Route("imget/")] // API Root Url
    [Route("imget/[controller]")]
    public class HealthCheck : Controller
    {
        /// <summary>
        /// Gets a reference to the HealthCheckConfig object created at application startup
        /// </summary>
        public IOptions<HealthCheckConfig> HealthCheckConfig { get; }

        /// <summary>
        /// The constructor injects the HeathCheckConfig object into the HealthCheck controller
        /// </summary>
        /// <param name="healthCheckConfig"></param>
        public HealthCheck(IOptions<HealthCheckConfig> healthCheckConfig)
        {
            HealthCheckConfig = healthCheckConfig;
        }

        /// <summary>
        /// System Health Check
        /// Gets information about the application.
        /// If this page can be hit the application is live.
        /// </summary>
        /// <returns>An Ok ActionResult containing the health check information</returns>
        /// <remarks>
        /// GET: imget/healthcheck
        /// </remarks>
        [HttpGet]
        public ActionResult GetHealthCheck()
        {
            var result = HealthCheckConfig;            

            return Ok(result);
        }        
    }
}

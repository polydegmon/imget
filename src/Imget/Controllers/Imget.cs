using Microsoft.AspNetCore.Mvc;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
/// </remarks>
namespace Imget.Controllers
{    
    [Route("imget")]    
    public class Imget : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// GET: imget
        /// </remarks>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Imget Application Entry Point - See imget/help for more information");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// GET: imget/help
        /// </remarks>
        [Route("help")]
        [HttpGet]
        public ActionResult GetHelp()
        {
            return Ok("Imget Application Help Page - More to come");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
/// </remarks>
namespace Imget.Controllers
{    
    /// <summary>
    /// 
    /// </summary>
    [Route("imget")]    
    public class Imget : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public string HelpUrl { get; }

        /// <summary>
        /// 
        /// </summary>
        public Imget()
        {
            // TODO: Inject this in from the appsettings.json file
            HelpUrl = "swagger/ui";
        }

        /// <summary>
        /// Application entry point
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Application entry point.
        /// This redirects the user to the help page
        /// 
        ///     GET: imget
        /// </remarks>
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok("Imget Application Entry Point - See imget/help for more information");
        }

        /// <summary>
        /// API Help Documentation
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Hitting this page will redirect the user to the help pages
        /// 
        ///     GET: imget/help
        ///     
        /// TODO: Implement Items from here - [https://docs.asp.net/en/latest/tutorials/web-api-help-pages-using-swagger.html#dataannotations]
        /// </remarks>
        [Route("help")]
        [HttpGet]
        public IActionResult GetHelp()
        {
            var url = string.Format("{0}://{1}/{2}", HttpContext.Request.Scheme, HttpContext.Request.Host, HelpUrl);

            return Redirect(url);            
        }
    }
}

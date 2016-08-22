using Microsoft.AspNetCore.Mvc;

/// <summary>
/// TODO: 
/// deploy to AWS
/// deploy to Azure
/// 
/// create authorization with single user and password
/// 
/// wire up database
/// 
/// controller - List
/// ------------------
/// list the image files
/// list the files by category
/// list categories 
/// 
/// controller - Image
/// ------------------
/// get a random image - done
/// get an image by category 
/// 
/// add an image
/// remove an image
/// update image category [set | remove] [category has to exist]
/// 
/// controller - Category
/// ------------------
/// create a category
/// remove a category
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
        public ActionResult Get()
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
        public ActionResult GetHelp()
        {
            var url = string.Format("{0}://{1}/{2}", HttpContext.Request.Scheme, HttpContext.Request.Host, HelpUrl);

            return Redirect(url);            
        }
    }
}

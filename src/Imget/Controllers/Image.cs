using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

/// <summary>
/// //todo: 
/// // get a random image
/// // get an image by category  
/// </summary>
/// <remarks>
/// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
/// </remarks>
namespace Imget.Controllers
{    
    [Route("imget/[controller]")]
    public class Image : Controller
    {
        /// <summary>
        /// String representing the location of the images for the application        
        /// </summary>
        public string ImagePath { get; }

        /// <summary>
        /// Hosting Environment property that holds the information about wwwroot for the application
        /// 
        /// Provides the current EnvironmentName, ContentRootPath, WebRootPath, and web root file provider. 
        /// Available to the Startup constructor and Configure method.
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Inject the hosting environment into the controller so we can have access to the application contents stored
        /// in the wwwroot folder
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public Image(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            ImagePath = "images";
        }

        /// <summary>
        /// Default GET operation
        /// Gets a random image and returns it to the caller
        /// This looks at all images in the wwwroot images folder
        /// </summary>
        /// <returns>
        /// A random file image
        /// </returns>
        /// <remarks>
        /// GET imget/image
        /// </remarks>
        [HttpGet]
        public ActionResult Get()
        {
            // Check if we have an image path, if not return a 500 error
            if (string.IsNullOrEmpty(ImagePath))
                return StatusCode(500, "Image path has not been defined");

            // Choose a random file from the image directory
            var filePath = GetRandomFileFromDirectory(ImagePath);

            // Return a 404 error if the file does not exist
            if (!System.IO.File.Exists(filePath))
                return StatusCode(404, string.Format("Image [{0}] not found", filePath));

            // Get the file extension
            var fileExt = Path.GetExtension(filePath).Replace(".", string.Empty);
            
            // Create the media type to be set in the header
            var mediaType = string.Format("images/{0}", fileExt);

            // Create a resposne that will send the physical file, with the media type header set
            var result = new PhysicalFileResult(filePath, mediaType);
            
            // Set the name of the downloaded file with the same name as the physical file
            result.FileDownloadName = Path.GetFileName(filePath);

            return result;            
        }

        /// <summary>
        /// Gets a random file from the directory
        /// </summary>
        /// <param name="directory">The directory to choose the random file from</param>
        /// <returns>A string containing the file path</returns>
        private string GetRandomFileFromDirectory(string directory)
        {
            // Gets the location of the wwwroot folder for the application
            string webRootPath = _hostingEnvironment.WebRootPath;

            // Creates the image path
            var folderPath = Path.Combine(webRootPath, directory);

            // Get a list of the files in the folder
            var fileList = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            // Get a random number for the fileList
            var fileListIndex = GetRandomNumber(fileList.Length - 1);

            // Return the selected file path from the list
            return fileList[fileListIndex];
        }

        /// <summary>
        /// Generates a random number between 0 and the maxValue 
        /// </summary>
        /// <param name="maxValue">The maximum value that can be randomly choosen</param>
        /// <returns>A random integer</returns>
        private int GetRandomNumber(int maxValue)
        {
            var fileListIndex = 0;

            // Seed the random generator with the current milisecond
            var random = new Random(DateTime.Now.Millisecond);

            // Generates the random number
            fileListIndex = random.Next(maxValue);

            return fileListIndex;
        }
    }
}

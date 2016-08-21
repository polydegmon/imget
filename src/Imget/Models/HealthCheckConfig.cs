using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Imget.Models
{    
    /// <summary>
    /// A class that represents the ApplicationInformation section of the appsettings.json file
    /// </summary>
    /// <remarks>
    /// JsonProperty changes the name of the property when it's rendered with the JsonSerializer
    /// </remarks>
    public class HealthCheckConfig
    {
        /// <summary>
        /// The name of the application
        /// </summary>        
        [Display(Name = "Application Name")]          
        [JsonProperty("Application Name")]
        public string Name { get; set; }

        /// <summary>
        /// The current version of the application
        /// </summary>
        [Display(Name = "Version")]       
        [JsonProperty("Version")] 
        public string Version { get; set; }        
    }
}

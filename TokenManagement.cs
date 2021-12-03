using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Platform.ApplicationServices
{/// <summary>
/// The TokenManagement class contains properties defined in the appsettings.json file 
/// and is used for accessing application settings via objects that are injected into classes 
/// using the ASP.NET Core built in dependency injection (DI) system.
/// </summary>
    [JsonObject("tokenManagement")]
    public class TokenManagement
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}

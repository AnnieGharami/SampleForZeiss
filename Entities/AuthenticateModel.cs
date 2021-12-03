using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Platform.ApplicationServices.AuthService
{
    public class AuthenticateModel
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }


        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
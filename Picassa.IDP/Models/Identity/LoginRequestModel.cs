using System.ComponentModel.DataAnnotations;

namespace Picassa.IDP.Models.Identity
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}

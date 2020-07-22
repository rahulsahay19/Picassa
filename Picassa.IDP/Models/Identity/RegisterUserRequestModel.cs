using System.ComponentModel.DataAnnotations;

namespace Picassa.IDP.Models.Identity
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email{ get; set; }
    }
}

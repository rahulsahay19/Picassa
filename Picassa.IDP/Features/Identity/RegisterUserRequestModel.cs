namespace Picassa.IDP.Features.Identity
{
    using System.ComponentModel.DataAnnotations;
    
    public class RegisterUserRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Picassa.IDP.Data.Models
{
    public class User: IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}

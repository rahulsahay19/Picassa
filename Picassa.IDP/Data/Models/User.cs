using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Picassa.IDP.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Picture> Pictures { get; } = new HashSet<Picture>();
    }
}

namespace Picassa.IDP.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        public IEnumerable<Picture> Pictures { get; } = new HashSet<Picture>();
    }
}

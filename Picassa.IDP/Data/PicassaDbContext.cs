using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Picassa.IDP.Data.Models;
using Picassa.IDP.Models;

namespace Picassa.IDP.Data
{
    public class PicassaDbContext : IdentityDbContext<User>
    {
        public PicassaDbContext(DbContextOptions<PicassaDbContext> options)
            : base(options)
        {
        }
    }
}

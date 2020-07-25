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

        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Picture>()
                .HasOne(u => u.User)
                .WithMany(c => c.Pictures)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

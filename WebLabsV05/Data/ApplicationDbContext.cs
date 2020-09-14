using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebLabsV05.DAL.Entities;
using WebLabsV05.Entities;

namespace WebLabsV05.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<AutoGroup> AutoGroups { get; set; }

        public
       ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
    }
}
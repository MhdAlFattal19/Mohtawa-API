using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Mohtawa.Infrastructure.Contexts
{
    public class LibraryIdentityContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

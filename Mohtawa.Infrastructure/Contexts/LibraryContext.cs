using Microsoft.EntityFrameworkCore;
using Mohtawa.Domain.Models;

namespace Mohtawa.Infrastructure.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* To Do Add Custom Configurations for entity */

            //modelBuilder.Entity<Book>(a =>
            //{

            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
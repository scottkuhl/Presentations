using EventManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    /// <summary>
    ///     Primary Entity Framework database context that supports Identity.
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("AspNetUsers");
            builder.Entity<AppUser>().Ignore(e => e.FullName);

            builder.Entity<Event>().ToTable("Event");
        }
    }
}
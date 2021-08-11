using System;
using CardApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CardApi.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // user email unique config
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}

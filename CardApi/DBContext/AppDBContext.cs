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
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


        public DbSet<User> DBUser { get; set; }
        public DbSet<Card> DBCard { get; set; }
    }
}

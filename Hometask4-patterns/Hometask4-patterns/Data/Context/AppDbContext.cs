using Hometask4_patterns.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hometask4_patterns.Data.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>(p =>
            {
                p.Property(x => x.CreationDate).HasDefaultValueSql("getDate()");
            });
        }

    }
}

using Microsoft.EntityFrameworkCore;
using UniBlog.Domain.Entities;

namespace UniBlog.Infrastructure;

public class UniBlogDbContext: DbContext
{
        public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    
    public UniBlogDbContext()
    {
    }

    public UniBlogDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniBlogDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
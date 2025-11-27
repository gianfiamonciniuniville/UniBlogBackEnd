using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniBlog.Domain.Entities;

namespace UniBlog.Infrastructure.Configuration;

public class BlogConfiguration() : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable(nameof(Blog));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.Description).IsRequired();
        builder.HasOne(b => b.User).WithMany(u => u.Blogs).HasForeignKey(b => b.UserId).IsRequired();
        builder.HasMany(b => b.Posts).WithOne(p => p.Blog).HasForeignKey(p => p.BlogId).IsRequired();

        builder.HasData([
            new Blog() { Id = 1, Title = "Blog 1", Description = "Test description blog 1", UserId = 1 },
            new Blog() { Id = 2, Title = "Blog 2", Description = "Test description blog 2", UserId = 1 }
        ]);
    }
}
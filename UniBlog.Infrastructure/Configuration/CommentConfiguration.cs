using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniBlog.Domain.Entities;

namespace UniBlog.Infrastructure.Configuration;

public class CommentConfiguration: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable(nameof(Comment));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Content).IsRequired();
        builder.HasOne(b => b.Post).WithMany(p => p.Comments).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(b => b.User).WithMany(u => u.Comments).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}
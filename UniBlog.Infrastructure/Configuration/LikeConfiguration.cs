using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniBlog.Domain.Entities;

namespace UniBlog.Infrastructure.Configuration;

public class LikeConfiguration: IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable(nameof(Like));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasOne(b => b.Post).WithMany(p => p.Likes).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(b => b.User).WithMany(u => u.Likes).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}
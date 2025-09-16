using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniBlog.Domain;
using UniBlog.Domain.Entities;

namespace UniBlog.Infrastructure.Configuration;

public class UserConfiguration(): IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.UserName).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Bio);
        builder.Property(p => p.PasswordHash).IsRequired();
        builder.Property(p => p.ProfileImageUrl);
        builder.Property(p => p.Role).HasDefaultValue(nameof(Role.Autor));
    }
}
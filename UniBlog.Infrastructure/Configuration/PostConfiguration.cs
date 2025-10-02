using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniBlog.Domain.Entities;

namespace UniBlog.Infrastructure.Configuration;

internal class PostConfiguration: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable(nameof(Post));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.Content).IsRequired();
        builder.Property(b => b.Slug).IsRequired();
        builder.HasOne(b => b.Blog).WithMany(b => b.Posts).HasForeignKey(b => b.BlogId);
        builder.HasOne(p => p.Author).WithMany().HasForeignKey(p => p.AuthorId).OnDelete(DeleteBehavior.Restrict);


        builder.HasData([
            new Post { Id = 1, Title = "A Day at the Beach", Content = "Swimming, building sandcastles, and finding seashells. The sunsets were stunning.", Slug = "a-day-at-the-beach", BlogId = 1, AuthorId = 1, Published = true, PublishedAt = DateTime.UtcNow },
            new Post { Id = 2, Title = "The City of Dreams", Content = "Walking through the city at night, it's like a dream come true. The lights and sounds are magic.", Slug = "the-city-of-dreams", BlogId = 2, AuthorId = 2, Published = true, PublishedAt = DateTime.UtcNow },
            new Post { Id = 3, Title = "The Power of Nature", Content = "Exploring the forrest and seeing the beauty of nature up close. It's awe-inspiring.", Slug = "the-power-of-nature", BlogId = 1, AuthorId = 1, Published = true, PublishedAt = DateTime.UtcNow },
            new Post { Id = 4, Title = "The Art of Music", Content = "Listening to a symphony was like a journey through the heart. The music took me to a different world.", Slug = "the-art-of-music", BlogId = 2, AuthorId = 2, Published = true, PublishedAt = DateTime.UtcNow },
            new Post { Id = 5, Title = "The Magic of Cooking", Content = "Experimenting with new recipes and creating something delicious. Every meal is a new adventure.", Slug = "the-magic-of-cooking", BlogId = 1, AuthorId = 1, Published = true, PublishedAt = DateTime.UtcNow },
        ]);
    }
}
using Microsoft.EntityFrameworkCore;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Infrastructure.Repositories;

public class PostRepository(UniBlogDbContext context): Repository<Post>(context), IPostRepository
{
    public IEnumerable<Post> ListAllPosts()
    {
        return context.Posts.AsEnumerable();
    }
    
    public Post? GetByIdAsync(int id)
    {
        return context.Posts.FindAsync(id).GetAwaiter().GetResult();
    }

    public Post? GetBySlug(string slug)
    {
        return context.Posts.FirstOrDefaultAsync(p => p.Slug == slug).GetAwaiter().GetResult();
    }

    public IEnumerable<Post> GetByAuthor(int authorId)
    {
        return context.Posts.Where(p => p.AuthorId == authorId).AsEnumerable();
    }
    
    public new Post Update(Post post)
    {
        var enty = context.Posts.Update(post);
        context.SaveChanges();
        return enty.Entity;
    }
    
    public new Post Create(Post post)
    {
        var enty = context.Posts.Add(post);
        context.SaveChanges();
        return enty.Entity;
    }
}
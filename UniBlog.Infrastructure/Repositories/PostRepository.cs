using Microsoft.EntityFrameworkCore;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Infrastructure.Repositories;

public class PostRepository(UniBlogDbContext context) : Repository<Post>(context), IPostRepository
{
    public async Task<IEnumerable<Post>> GetAllWithDetailsAsync()
    {
        return await context.Posts
            .Include(p => p.Blog)
            .Include(p => p.Author)
            .Include(p => p.Comments)
            .ThenInclude(c => c.User)
            .Include(p => p.Likes)
            .ThenInclude(l => l.User)
            .ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await context.Posts
            .Include(p => p.Blog)
            .Include(p => p.Author)
            .Include(p => p.Comments)
            .ThenInclude(c => c.User)
            .Include(p => p.Likes)
            .ThenInclude(l => l.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Post?> GetBySlugWithDetailsAsync(string slug)
    {
        return await context.Posts
            .Include(p => p.Blog)
            .Include(p => p.Author)
            .Include(p => p.Comments)
            .ThenInclude(c => c.User)
            .Include(p => p.Likes)
            .ThenInclude(l => l.User)
            .FirstOrDefaultAsync(p => p.Slug == slug);
    }

    public async Task<IEnumerable<Post>> GetByAuthorWithDetailsAsync(int authorId)
    {
        return await context.Posts
            .Where(p => p.AuthorId == authorId)
            .Include(p => p.Author)
            .Include(p => p.Blog)
            .Include(p => p.Comments)
            .ThenInclude(c => c.User)
            .Include(p => p.Likes)
            .ThenInclude(l => l.User)
            .ToListAsync();
    }

    public async Task<Post> UpdateAsync(Post post)
    {
        var entry = context.Posts.Update(post);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        var entry = context.Posts.Add(post);
        await context.SaveChangesAsync();
        return entry.Entity;
    }
    
    public async Task<Post> DeleteAsync(Post post)
    {
        var entry = context.Posts.Remove(post);
        await context.SaveChangesAsync();
        return entry.Entity;
    }
}
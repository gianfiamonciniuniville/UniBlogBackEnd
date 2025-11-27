using Microsoft.EntityFrameworkCore;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;
using UniBlog.Infrastructure.Repositories;

namespace UniBlog.Infrastructure.Repositories;

public class BlogRepository(UniBlogDbContext context) : Repository<Blog>(context), IBlogRepository
{
    public async Task<IEnumerable<Blog>> GetAllWithDetailsAsync()
    {
        return await context.Blogs
            .Include(b => b.User)
            .Include(b => b.Posts)
            .ToListAsync();
    }

    public async Task<IEnumerable<Blog>> GetAllWithDetailsByAuthorAsync(int authorId)
    {
        return await context.Blogs
            .Include(b => b.User)
            .Include(b => b.Posts)
            .Where(b => b.UserId == authorId)
            .ToListAsync();
    }

    public async Task<Blog?> GetByIdWithDetailsAsync(int id)
    {
        return await context.Blogs
            .Include(b => b.User)
            .Include(b => b.Posts)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Blog> CreateAsync(Blog blog)
    {
        var entry = context.Blogs.Add(blog);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<Blog> UpdateAsync(Blog blog)
    {
        var entry = context.Blogs.Update(blog);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blog = await context.Blogs.FindAsync(id);
        if (blog == null)
        {
            return false;
        }

        context.Blogs.Remove(blog);
        await context.SaveChangesAsync();
        return true;
    }
}

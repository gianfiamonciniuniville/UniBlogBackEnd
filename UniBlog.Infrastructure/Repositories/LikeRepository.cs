using Microsoft.EntityFrameworkCore;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;
using UniBlog.Infrastructure.Repositories;

namespace UniBlog.Infrastructure.Repositories;

public class LikeRepository(UniBlogDbContext context) : Repository<Like>(context), ILikeRepository
{
    public async Task<Like> CreateAsync(Like like)
    {
        var entry = context.Likes.Add(like);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var like = await context.Likes.FindAsync(id);
        if (like == null)
        {
            return false;
        }

        context.Likes.Remove(like);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Like?> GetByPostAndUserAsync(int postId, int userId)
    {
        return await context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
    }
}

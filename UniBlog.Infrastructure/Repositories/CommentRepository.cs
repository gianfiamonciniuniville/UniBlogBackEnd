using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;
using UniBlog.Infrastructure.Repositories;

namespace UniBlog.Infrastructure.Repositories;

public class CommentRepository(UniBlogDbContext context) : Repository<Comment>(context), ICommentRepository
{
    public async Task<Comment> CreateAsync(Comment comment)
    {
        var entry = context.Comments.Add(comment);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment == null)
        {
            return false;
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
        return true;
    }
}

using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Infrastructure.Repositories;

public class PostRepository(UniBlogDbContext context): Repository<Post>(context), IPostRepository
{
    public IEnumerable<Post> ListAllPosts()
    {
        return context.Posts.AsEnumerable();
    }
}
using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface IPostRepository
{
    public IEnumerable<Post> ListAllPosts();
}
using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface IPostRepository: IRepository<Post>
{
    Task<IEnumerable<Post>> GetAllWithDetailsAsync();
    Task<Post?> GetByIdAsync(int id);
    Task<Post?> GetBySlugWithDetailsAsync(string slug);
    Task<IEnumerable<Post>> GetByAuthorWithDetailsAsync(int authorId);
    Task<Post> UpdateAsync(Post post);
    Task<Post> CreateAsync(Post post);
}
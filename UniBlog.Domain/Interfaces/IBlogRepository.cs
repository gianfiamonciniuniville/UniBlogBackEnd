using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface IBlogRepository : IRepository<Blog>
{
    Task<IEnumerable<Blog>> GetAllWithDetailsAsync();
    Task<IEnumerable<Blog>> GetAllWithDetailsByAuthorAsync(int authorId);
    Task<Blog?> GetByIdWithDetailsAsync(int id);
    Task<Blog> CreateAsync(Blog blog);
    Task<Blog> UpdateAsync(Blog blog);
    Task<bool> DeleteAsync(int id);
}

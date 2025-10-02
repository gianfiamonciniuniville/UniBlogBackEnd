using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface ILikeRepository: IRepository<Like>
{
    Task<Like> CreateAsync(Like like);
    Task<bool> DeleteAsync(int id);
    Task<Like?> GetByPostAndUserAsync(int postId, int userId);
}

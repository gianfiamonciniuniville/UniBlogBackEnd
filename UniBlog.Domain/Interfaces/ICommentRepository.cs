using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface ICommentRepository: IRepository<Comment>
{
    Task<Comment> CreateAsync(Comment comment);
    Task<bool> DeleteAsync(int id);
}

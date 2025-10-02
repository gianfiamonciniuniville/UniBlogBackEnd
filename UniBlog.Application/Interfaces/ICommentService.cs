using UniBlog.Application.DTO;

namespace UniBlog.Application.Interfaces;

public interface ICommentService
{
    Task<CommentDto> Create(CommentCreateDto comment);
    Task<bool> Delete(int id);
}

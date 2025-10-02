using UniBlog.Application.DTO;

namespace UniBlog.Application.Interfaces;

public interface ILikeService
{
    Task<LikeDto> Create(LikeCreateDto like);
    Task<bool> Delete(int id);
}

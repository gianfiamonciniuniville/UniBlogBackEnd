using UniBlog.Application.DTO;

namespace UniBlog.Application.Interfaces;

public interface IBlogService
{
    Task<IEnumerable<BlogDto>> GetAll();
    Task<BlogDto?> GetById(int id);
    Task<BlogDto> Create(BlogCreateDto blog);
    Task<BlogDto> Update(int id, BlogUpdateDto blog);
    Task<bool> Delete(int id);
}

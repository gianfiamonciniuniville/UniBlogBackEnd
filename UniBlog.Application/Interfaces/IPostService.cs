using UniBlog.Application.DTO;

namespace UniBlog.Application.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostDto>> ListAll();
    Task<PostDto> CreatePost(PostCreateDto post);
    Task<PostDto> EditPost(int id, PostUpdateDto post);
    Task<PostDto> PublishPost(int id);
    Task<PostDto?> GetBySlug(string slug);
    Task<IEnumerable<PostDto>> GetByAuthor(int authorId);
}
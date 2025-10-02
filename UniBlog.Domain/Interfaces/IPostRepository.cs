using UniBlog.Domain.Entities;

namespace UniBlog.Domain.Interfaces;

public interface IPostRepository: IRepository<Post>
{
    public IEnumerable<Post> ListAllPosts();
    public Post? GetByIdAsync(int id);
    public Post? GetBySlug(string slug);
    public IEnumerable<Post> GetByAuthor(int authorId);
    public new Post Update(Post post);
    public new Post Create(Post post);
}
using UniBlog.Domain.Entities;

namespace UniBlog.Application.Interfaces;

public interface IPostService
{
    public IEnumerable<Post> ListAll();
    public Post CreatePost(Post post);
    public Post EditPost(int id, Post post);
    public Post PublishPost(int id);
    public Post? GetBySlug(string slug);
    public IEnumerable<Post> GetByAuthor(int authorId);
}
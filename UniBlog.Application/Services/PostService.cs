using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Application.Services;

public class PostService(IPostRepository postRepository): IPostService
{
    public IEnumerable<Post> ListAll()
    {
        return postRepository.ListAllPosts();
    }

    public Post CreatePost(Post post)
    {
        // TODO: Add validation
        return postRepository.Create(post);
    }

    public Post EditPost(int id, Post post)
    {
        // TODO: Add validation
        var existingPost = postRepository.GetByIdAsync(id)
            ?? throw new Exception("Post not found");
        
        existingPost.Title = post.Title;
        existingPost.Content = post.Content;
        existingPost.Slug = post.Slug;
        
        return postRepository.Update(existingPost);
    }

    public Post PublishPost(int id)
    {
        var existingPost = postRepository.GetByIdAsync(id)
            ?? throw new Exception("Post not found");

        existingPost.Published = !existingPost.Published;
        existingPost.PublishedAt = DateTime.UtcNow;

        return postRepository.Update(existingPost);
    }

    public Post? GetBySlug(string slug)
    {
        return postRepository.GetBySlug(slug);
    }

    public IEnumerable<Post> GetByAuthor(int authorId)
    {
        return postRepository.GetByAuthor(authorId);
    }
}
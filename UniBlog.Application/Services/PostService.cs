using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Application.Services;

public class PostService(IPostRepository postRepository) : IPostService
{
    public async Task<IEnumerable<PostDto>> ListAll()
    {
        var posts = await postRepository.GetAllWithDetailsAsync();
        return posts.Select(p => new PostDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            Slug = p.Slug,
            Published = p.Published,
            PublishedAt = p.PublishedAt,
            ViewCount = p.ViewCount,
            Author = new UserShortDto { Id = p.Author.Id, UserName = p.Author.UserName, ProfileImageUrl = p.Author.ProfileImageUrl },
            Comments = p.Comments?.Select(c => new CommentDto { Id = c.Id, Content = c.Content, User = new UserShortDto { Id = c.User.Id, UserName = c.User.UserName, ProfileImageUrl = c.User.ProfileImageUrl } }) ?? new List<CommentDto>(),
            Likes = p.Likes?.Select(l => new LikeDto { Id = l.Id, User = new UserShortDto { Id = l.User.Id, UserName = l.User.UserName, ProfileImageUrl = l.User.ProfileImageUrl } }) ?? new List<LikeDto>()
        });
    }

    public async Task<PostDto> CreatePost(PostCreateDto postDto)
    {
        var post = new Post
        {
            Title = postDto.Title,
            Content = postDto.Content,
            Slug = postDto.Slug,
            AuthorId = postDto.AuthorId,
            BlogId = postDto.BlogId
        };

        var createdPost = await postRepository.CreateAsync(post);
        return await GetBySlug(createdPost.Slug);
    }

    public async Task<PostDto> EditPost(int id, PostUpdateDto postDto)
    {
        var existingPost = await postRepository.GetByIdAsync(id)
            ?? throw new Exception("Post not found");

        existingPost.Title = postDto.Title;
        existingPost.Content = postDto.Content;
        existingPost.Slug = postDto.Slug;

        var updatedPost = await postRepository.UpdateAsync(existingPost);
        return await GetBySlug(updatedPost.Slug);
    }

    public async Task<PostDto> PublishPost(int id)
    {
        var existingPost = await postRepository.GetByIdAsync(id)
            ?? throw new Exception("Post not found");

        existingPost.Published = !existingPost.Published;
        existingPost.PublishedAt = DateTime.UtcNow;

        var updatedPost = await postRepository.UpdateAsync(existingPost);
        return await GetBySlug(updatedPost.Slug);
    }

    public async Task<PostDto?> GetBySlug(string slug)
    {
        var p = await postRepository.GetBySlugWithDetailsAsync(slug);
        if (p == null) return null;

        return new PostDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            Slug = p.Slug,
            Published = p.Published,
            PublishedAt = p.PublishedAt,
            ViewCount = p.ViewCount,
            Author = new UserShortDto { Id = p.Author.Id, UserName = p.Author.UserName, ProfileImageUrl = p.Author.ProfileImageUrl },
            Comments = p.Comments?.Select(c => new CommentDto { Id = c.Id, Content = c.Content, User = new UserShortDto { Id = c.User.Id, UserName = c.User.UserName, ProfileImageUrl = c.User.ProfileImageUrl } }) ?? new List<CommentDto>(),
            Likes = p.Likes?.Select(l => new LikeDto { Id = l.Id, User = new UserShortDto { Id = l.Id, UserName = l.User.UserName, ProfileImageUrl = l.User.ProfileImageUrl } }) ?? new List<LikeDto>()
        };
    }

    public async Task<IEnumerable<PostDto>> GetByAuthor(int authorId)
    {
        var posts = await postRepository.GetByAuthorWithDetailsAsync(authorId);
        return posts.Select(p => new PostDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            Slug = p.Slug,
            Published = p.Published,
            PublishedAt = p.PublishedAt,
            ViewCount = p.ViewCount,
            Author = new UserShortDto { Id = p.Author.Id, UserName = p.Author.UserName, ProfileImageUrl = p.Author.ProfileImageUrl },
            Comments = p.Comments?.Select(c => new CommentDto { Id = c.Id, Content = c.Content, User = new UserShortDto { Id = c.User.Id, UserName = c.User.UserName, ProfileImageUrl = c.User.ProfileImageUrl } }) ?? new List<CommentDto>(),
            Likes = p.Likes?.Select(l => new LikeDto { Id = l.Id, User = new UserShortDto { Id = l.User.Id, UserName = l.User.UserName, ProfileImageUrl = l.User.ProfileImageUrl } }) ?? new List<LikeDto>()
        });
    }
}
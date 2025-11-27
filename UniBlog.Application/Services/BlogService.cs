using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Application.Services;

public class BlogService(IBlogRepository blogRepository) : IBlogService
{
    public async Task<IEnumerable<BlogDto>> GetAll()
    {
        var blogs = await blogRepository.GetAllWithDetailsAsync();
        return blogs.Select(b => new BlogDto
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            User = b.User != null ? new UserShortDto { Id = b.User.Id, UserName = b.User.UserName, ProfileImageUrl = b.User.ProfileImageUrl } : null,
            Posts = b.Posts?.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Slug = p.Slug,
                Published = p.Published,
                PublishedAt = p.PublishedAt,
                ViewCount = p.ViewCount
            }) ?? new List<PostDto>()
        });
    }

    public async Task<IEnumerable<BlogDto>> GetAllBlogsByAuthor(int authorId)
    {
        var blogs = await blogRepository.GetAllWithDetailsByAuthorAsync(authorId);
        return blogs.Select(b => new BlogDto
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            User = b.User != null ? new UserShortDto { Id = b.User.Id, UserName = b.User.UserName, ProfileImageUrl = b.User.ProfileImageUrl } : null,
            Posts = b.Posts?.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Slug = p.Slug,
                Published = p.Published,
                PublishedAt = p.PublishedAt,
                ViewCount = p.ViewCount
            }) ?? new List<PostDto>()
        });
    }

    public async Task<BlogDto?> GetById(int id)
    {
        var b = await blogRepository.GetByIdWithDetailsAsync(id);
        if (b == null) return null;

        return new BlogDto
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            User = b.User != null ? new UserShortDto { Id = b.User.Id, UserName = b.User.UserName, ProfileImageUrl = b.User.ProfileImageUrl } : null,
            Posts = b.Posts?.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Slug = p.Slug,
                Published = p.Published,
                PublishedAt = p.PublishedAt,
                ViewCount = p.ViewCount
            }) ?? new List<PostDto>()
        };
    }

    public async Task<BlogDto> Create(BlogCreateDto blogDto)
    {
        var blog = new Blog
        {
            Title = blogDto.Title,
            Description = blogDto.Description,
            UserId = blogDto.UserId
        };

        var createdBlog = await blogRepository.CreateAsync(blog);
        return await GetById(createdBlog.Id) ?? throw new Exception("Blog not found after creation.");
    }

    public async Task<BlogDto> Update(int id, BlogUpdateDto blogDto)
    {
        var existingBlog = await blogRepository.GetByIdWithDetailsAsync(id)
            ?? throw new Exception("Blog not found");

        existingBlog.Title = blogDto.Title;
        existingBlog.Description = blogDto.Description;

        var updatedBlog = await blogRepository.UpdateAsync(existingBlog);
        return await GetById(updatedBlog.Id) ?? throw new Exception("Blog not found after update.");
    }

    public async Task<bool> Delete(int id)
    {
        return await blogRepository.DeleteAsync(id);
    }
}

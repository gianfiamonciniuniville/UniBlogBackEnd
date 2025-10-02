using Microsoft.AspNetCore.Mvc;
using UniBlog.Application.Interfaces;
using UniBlog.Domain.Entities;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController(IPostService postService): ControllerBase
{
    [HttpGet]
    public IActionResult ListAllPosts()
    {
        try
        {
            var all = postService.ListAll();
            return Ok(all);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] Post post)
    {
        try
        {
            var createdPost = postService.CreatePost(post);
            return CreatedAtAction(nameof(GetBySlug), new { slug = createdPost.Slug }, createdPost);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult EditPost(int id, [FromBody] Post post)
    {
        try
        {
            var editedPost = postService.EditPost(id, post);
            if (editedPost == null)
            {
                return NotFound();
            }
            return Ok(editedPost);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}/publish")]
    public IActionResult PublishPost(int id)
    {
        try
        {
            var publishedPost = postService.PublishPost(id);
            if (publishedPost == null)
            {
                return NotFound();
            }
            return Ok(publishedPost);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("slug/{slug}")]
    public IActionResult GetBySlug(string slug)
    {
        try
        {
            var post = postService.GetBySlug(slug);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("author/{authorId}")]
    public IActionResult GetByAuthor(int authorId)
    {
        try
        {
            var posts = postService.GetByAuthor(authorId);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
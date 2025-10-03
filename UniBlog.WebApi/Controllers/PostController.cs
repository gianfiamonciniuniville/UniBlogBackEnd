using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController(IPostService postService) : ControllerBase
{
    [HttpGet("all")]
    [EndpointSummary("Lista todas as publicações")]
    [EndpointDescription("Obtém uma lista de todas as publicações cadastradas no sistema.")]
    public async Task<IActionResult> ListAllPosts()
    {
        try
        {
            var all = await postService.ListAll();
            return Ok(all);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [EndpointSummary("Cria uma nova publicação")]
    [EndpointDescription("Cria uma nova publicação com os dados fornecidos.")]
    public async Task<IActionResult> CreatePost([FromBody] PostCreateDto post)
    {
        try
        {
            var createdPost = await postService.CreatePost(post);
            return CreatedAtAction(nameof(GetBySlug), new { slug = createdPost.Slug }, createdPost);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [EndpointSummary("Edita uma publicação existente")]
    [EndpointDescription("Edita os dados de uma publicação existente a partir do seu ID.")]
    public async Task<IActionResult> EditPost(int id, [FromBody] PostUpdateDto post)
    {
        try
        {
            var editedPost = await postService.EditPost(id, post);
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
    [EndpointSummary("Publica uma publicação")]
    [EndpointDescription("Torna uma publicação visível para o público.")]
    public async Task<IActionResult> PublishPost(int id)
    {
        try
        {
            var publishedPost = await postService.PublishPost(id);
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
    [EndpointSummary("Obtém uma publicação pelo slug")]
    [EndpointDescription("Obtém os detalhes de uma publicação específica pelo seu slug.")]
    public async Task<IActionResult> GetBySlug(string slug)
    {
        try
        {
            var post = await postService.GetBySlug(slug);
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
    [EndpointSummary("Obtém publicações por autor")]
    [EndpointDescription("Obtém uma lista de publicações de um autor específico.")]
    public async Task<IActionResult> GetByAuthor(int authorId)
    {
        try
        {
            var posts = await postService.GetByAuthor(authorId);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
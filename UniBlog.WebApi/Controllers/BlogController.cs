using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController(IBlogService blogService) : ControllerBase
{
    [HttpGet("all")]
    [EndpointSummary("Obtém todos os blogs")]
    [EndpointDescription("Obtém a lista de todos os blogs cadastrados no sistema.")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var blogs = await blogService.GetAll();
            return Ok(blogs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    [EndpointSummary("Obtém um blog pelo ID")]
    [EndpointDescription("Obtém os detalhes de um blog específico pelo seu ID.")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var blog = await blogService.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [EndpointSummary("Cria um novo blog")]
    [EndpointDescription("Cria um novo blog com os dados fornecidos.")]
    public async Task<IActionResult> Create([FromBody] BlogCreateDto blog)
    {
        try
        {
            var createdBlog = await blogService.Create(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [EndpointSummary("Atualiza um blog existente")]
    [EndpointDescription("Atualiza os dados de um blog existente a partir do seu ID.")]
    public async Task<IActionResult> Update(int id, [FromBody] BlogUpdateDto blog)
    {
        try
        {
            var updatedBlog = await blogService.Update(id, blog);
            if (updatedBlog == null)
            {
                return NotFound();
            }
            return Ok(updatedBlog);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Exclui um blog")]
    [EndpointDescription("Exclui um blog do sistema a partir do seu ID.")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await blogService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

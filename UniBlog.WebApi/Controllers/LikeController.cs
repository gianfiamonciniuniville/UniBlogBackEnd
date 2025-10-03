using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController(ILikeService likeService) : ControllerBase
{
    [HttpPost]
    [EndpointSummary("Cria um novo like")]
    [EndpointDescription("Cria um novo like em uma publicação.")]
    public async Task<IActionResult> Create([FromBody] LikeCreateDto like)
    {
        try
        {
            var createdLike = await likeService.Create(like);
            return Ok(createdLike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Remove um like")]
    [EndpointDescription("Remove um like de uma publicação a partir do seu ID.")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await likeService.Delete(id);
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

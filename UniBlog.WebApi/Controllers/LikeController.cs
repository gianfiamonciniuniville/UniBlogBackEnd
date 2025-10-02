using Microsoft.AspNetCore.Mvc;
using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController(ILikeService likeService) : ControllerBase
{
    [HttpPost]
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

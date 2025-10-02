using Microsoft.AspNetCore.Mvc;
using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController(ICommentService commentService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentCreateDto comment)
    {
        try
        {
            var createdComment = await commentService.Create(comment);
            return Ok(createdComment);
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
            var result = await commentService.Delete(id);
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

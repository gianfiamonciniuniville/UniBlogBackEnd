using Microsoft.AspNetCore.Mvc;
using UniBlog.Domain.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController(IPostRepository postRepository): ControllerBase
{
    [HttpGet]
    public IActionResult ListAllPosts()
    {
        try
        {
            return Ok(postRepository.ListAllPosts());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using UniBlog.Application.Interfaces;
using UniBlog.Domain.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController(IPostService postService): ControllerBase
{
    private readonly IPostService _postService = postService;
    
    [HttpGet]
    public IActionResult ListAllPosts()
    {
        try
        {
            return Ok(_postService.ListAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
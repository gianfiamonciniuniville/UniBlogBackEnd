using Microsoft.AspNetCore.Mvc;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok("Deu boa!!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Endpoint de teste")]
    [EndpointDescription("Retorna uma mensagem de sucesso para testar a API.")]
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

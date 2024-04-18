using Microsoft.AspNetCore.Mvc;

namespace PhoenixAPI;

[Route("api/v1/authorization")]
[ApiController]
public class AuthorizeController : ControllerBase
{
    private readonly AuthorizeService _authorizeService;

    public AuthorizeController(AuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }

    [HttpPost]
    public IActionResult Login(RequestDTO requestDTO){
        try
        {
            var response = _authorizeService.GetToken(requestDTO);
            return Ok(response);
        }
        catch (Exception exception)
        {
            return Unauthorized(exception.Message);
        }
    }
}

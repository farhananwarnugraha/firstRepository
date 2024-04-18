using Microsoft.AspNetCore.Mvc;

namespace PhoenixAPI;
[Route("api/v1/admin")]
[ApiController]
public class AuthController:ControllerBase
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }

    [HttpPost("Register")]
    public IActionResult Register(AuthRegisterDTO dto){
        try
        {
            _service.SetRegister(dto);
            return Ok("Register Sucessed");
        }
        catch (Exception e)
        {
            return BadRequest("Register Failed");
        }
    }
}

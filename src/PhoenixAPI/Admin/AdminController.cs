using Microsoft.AspNetCore.Mvc;
using PhoenixBusiness;

namespace PhoenixAPI;
[Route("api/v1/adminstrator")]
[ApiController]
public class AdminController:ControllerBase
{
    private readonly AdminService _service;

    public AdminController(AdminService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Update(string username){
        var model = _service.Get(username);
        return Ok(model);
    }

    [HttpPut]
    public IActionResult Update(AdminDTO adminDTO){
        _service.Update(adminDTO);
        return Ok("Update Done");
    }
}

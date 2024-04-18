using Microsoft.AspNetCore.Mvc;

namespace PhoenixAPI;

[Route("api/v1/roomservice")]
[ApiController]
public class RoomServiceController : ControllerBase
{
    private readonly RsService _service;

    public RoomServiceController(RsService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Insert(RoomServiceDTO model){
        _service.Insert(model);
        return Ok("Inputed Successed");
    }

    [HttpGet]
    public IActionResult Get(string employeeNumber){
        var model = _service.Get(employeeNumber);
        return Ok(model);
    }

    [HttpPut]
    public IActionResult Update(RoomServiceDTO model){
        _service.Update(model);
        return Ok("Update Employee Successed");
    }
}

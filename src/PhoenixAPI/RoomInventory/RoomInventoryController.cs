using Microsoft.AspNetCore.Mvc;

namespace PhoenixAPI;
[Route("api/v1/roominventory")]
[ApiController]
public class RoomInventoryController : ControllerBase
{
    public readonly RoomInventoryService _service;

    public RoomInventoryController(RoomInventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Add(string roomNumber){
        var viewModel = _service.Add(roomNumber);
        return Ok(viewModel);
    }

    [HttpPost]
    public IActionResult Insert(RoomInventoryDTO viewModel){        
        _service.Insert(viewModel);
        return Ok("Success Inputed");
        
    }

    [HttpDelete]
    public IActionResult Delete(long idInventory){
        _service.Delete(idInventory);
        return Ok("Deleted Successed");
    }
}

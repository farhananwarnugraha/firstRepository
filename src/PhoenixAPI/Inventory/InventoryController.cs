using Microsoft.AspNetCore.Mvc;

namespace PhoenixAPI;

[Route("api/v1/Inventory")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _service;

    public InventoryController(InventoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Insert(InventoryDTO inventoryDTO){
        _service.Insert(inventoryDTO);
        return Ok("Inventory hass been Inputed");
    }

    [HttpGet]
    public IActionResult Update(string name){
        var model = _service.Get(name);
        return Ok(model);
    }

    [HttpPut]
    public IActionResult Update(InventoryDTO inventoryDTO){
        _service.Update(inventoryDTO);
        return Ok("Inventory Successed Update");
    }

    [HttpDelete]
    public IActionResult Delete(string name){
        try{
            _service.Delete(name);
            return Ok("Delete Successed");
        }catch(Exception e){
            return Unauthorized("Not Have Access");
        }
    }
}

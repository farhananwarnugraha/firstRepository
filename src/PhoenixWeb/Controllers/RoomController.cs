using Microsoft.AspNetCore.Mvc;
using PhoenixWeb.ViewModels.Room;

namespace PhoenixWeb;

public class RoomController : Controller
{
    private readonly RoomsService _service;

    public RoomController(RoomsService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=5, string roomNumber="", string roomType=""){
       var vm =  _service.Get(pageNumber, pageSize, roomNumber, roomType);
        ViewData["title"] = "Room";
        return View(vm);
    }

    [HttpGet("Room/Insert")]
    public IActionResult Insert(){
        ViewData["title"] = "Add Room";
        var vieModel = _service.GetForm();
        return View("InsertUpdate", vieModel);
    }

    [HttpPost]
    public IActionResult Insert(RoomUpsertViewModel model){
        if(ModelState.IsValid){
            _service.Insert(model);
            return RedirectToAction("Index");
        }
        var vm = _service.GetForm();
        return View("InsertUpdate", vm);
    }

    [HttpGet("Room/{roomNumber}")]
    public IActionResult Edit(string roomNumber){
        ViewData["title"] = "Add Room";
        var vieModel = _service.Get(roomNumber);
        return View("InsertUpdate", vieModel);
    }

    [HttpPost("Room/{roomNumber}")]
    public IActionResult Edit(RoomUpsertViewModel model){
        if(ModelState.IsValid){
            _service.Update(model);
            return RedirectToAction("Index");
        }
        var vm = _service.GetForm();
        return View("InsertUpdate", vm);
    }

    [HttpGet("RoomItem/{roomNumber}")]
    public IActionResult Item(string roomNumber){
        ViewData["title"] = "Room Inventory";
        var model = _service.GetDetailRoom(roomNumber);
        return View("RoomInventory", model);
    }
}

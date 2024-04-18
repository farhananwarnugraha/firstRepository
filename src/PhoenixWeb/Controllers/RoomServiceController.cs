using Microsoft.AspNetCore.Mvc;
using PhoenixWeb.ViewModels.RoomServices;

namespace PhoenixWeb;

public class RoomServiceController : Controller
{
    private readonly RoomServicesService _service;

    public RoomServiceController(RoomServicesService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=5, string employeeNumber="", string fullName=""){
        var vm = _service.Get(pageNumber, pageSize, employeeNumber, fullName);
        ViewData["title"] = "Room Service";
        return View(vm);
    }
    
    [HttpGet("roomService/{employeeNumber}")]
    public IActionResult Roaster(string employeeNumber){
        var viewModel = _service.GetDetail(employeeNumber);
        ViewData["title"] = "Room Service";
        return View("DetailRoomService", viewModel);
    }

    [HttpPost("roomService/{employeeNumber}")]
    public IActionResult Update(string employeeNumber ,DetailRoomServiceViewModel model){
        _service.Update(employeeNumber,model);
        return RedirectToAction("Roaster", new {employeeNumber});
    }
}

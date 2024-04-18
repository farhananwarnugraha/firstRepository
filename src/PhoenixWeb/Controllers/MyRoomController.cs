using Microsoft.AspNetCore.Mvc;

namespace PhoenixWeb;

public class MyRoomController : Controller
{
    public IActionResult Index(){
        return View();
    }
}

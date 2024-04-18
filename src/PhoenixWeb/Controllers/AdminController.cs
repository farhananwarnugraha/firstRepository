using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhoenixWeb;

[Authorize(Roles ="Administrator")]
public class AdminController : Controller
{
    private readonly AdminService _service;

    public AdminController(AdminService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index(int pageNumber=1, int pageSize=5){
        ViewData["title"] = "Admin";
        var viewModel = _service.Get(pageNumber, pageSize);
        return View(viewModel);
    }
}

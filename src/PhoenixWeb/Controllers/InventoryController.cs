using Microsoft.AspNetCore.Mvc;

namespace PhoenixWeb;

public class InventoryController : Controller
{
    private readonly InventoryService _service;

    public InventoryController(InventoryService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=5){
        ViewData["title"] = "Inventory";
        var viewModel = _service.Get(pageNumber, pageSize);
        return View(viewModel);
    }
}

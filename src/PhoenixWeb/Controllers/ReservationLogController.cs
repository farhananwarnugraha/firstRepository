using Microsoft.AspNetCore.Mvc;

namespace PhoenixWeb;

public class ReservationLog : Controller
{
    private readonly ReservationService _service;

    public ReservationLog(ReservationService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=5,string roomNumber="", string guestNumber=""){
        var viewModel = _service.Get(pageNumber, pageSize, roomNumber,guestNumber);
        return View("Index", viewModel);
    }
}

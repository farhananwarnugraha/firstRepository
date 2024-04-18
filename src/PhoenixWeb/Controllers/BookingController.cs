using Microsoft.AspNetCore.Mvc;
using PhoenixWeb.ViewModels.Reservation;

namespace PhoenixWeb;

public class BookingController : Controller
{
    private readonly RoomsService _serviceRoom;
    private readonly ReservationService _service;

    public BookingController(RoomsService serviceRoom, ReservationService service)
    {
        _serviceRoom = serviceRoom;
        _service = service;
    }

    public IActionResult Index(int pageNumber=1, int pageSize=5, string roomNumber="", string roomType=""){
        ViewData["title"] = "Booking";
        var viewModel = _serviceRoom.Get(pageNumber, pageSize, roomNumber, roomType);
        return View("BookingIndex", viewModel);
    }

    [HttpGet("roomdetail/{roomNumber}")]
    public IActionResult Detail(string roomNumber){
        ViewData["title"] = "Booking";
        var viewModel = _serviceRoom.DetailRoom(roomNumber);
        return View("DetailRoom", viewModel);
    }

    [HttpGet("makereservation/{roomNumber}")]
    public IActionResult AddResevation(string roomNumber){
        ViewData["title"] = "Booking";
        var viewModel = _service.Get(roomNumber);
        return View("MakeReservation", viewModel);
    }

    [HttpPost]
    public IActionResult AddReservation(MakeReservationViewModel model){
        var guestNumber = User.FindFirst("username").Value;
        _service.Insert(guestNumber, model);
        return RedirectToAction("Index");
    }
}

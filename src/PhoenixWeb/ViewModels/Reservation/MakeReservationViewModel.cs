using PhoenixWeb.ViewModels.Room;

namespace PhoenixWeb.ViewModels.Reservation;

public class MakeReservationViewModel
{
    public DetailRoomViewModel DetailRooms { get; set; }
    public string Code { get; set; } = null!;
    public string ReservationMethod { get; set; } = null!;
    public string RoomNumber { get; set; } = null!;
    public string GuestNumber { get; set; } = null!;
    public DateTime BookDate { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal Cost { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = null!;
    public string? Remark { get; set; }
}

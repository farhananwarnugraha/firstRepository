namespace PhoenixWeb.ViewModels.Room;

public class RoomIndexViewModel
{
    public List<RoomViewModel>? Rooms { get; set; }
    public PaginatinViewModel? Paginations { get; set; }
    public string RoomNumber { get; set; }
    public string RoomType { get; set; }
}

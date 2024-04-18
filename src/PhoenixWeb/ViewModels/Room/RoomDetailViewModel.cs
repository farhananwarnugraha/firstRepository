using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.RoomInventory;

namespace PhoenixWeb.ViewModels.Room;

public class RoomDetailViewModel
{
    public string Number { get; set; } = null!;
    public int Floor { get; set; }
    public string RoomType { get; set; } = null!;
    public int GuestLimit { get; set; }
    public List<RoomInventoryViewModel>? RoomInventories { get; set; }
    public PaginatinViewModel? Paginations { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace PhoenixWeb.ViewModels.Room;

public class RoomUpsertViewModel
{
    [Required]
    public string Number { get; set; } = null!;
    public int Floor { get; set; }
    public string RoomType { get; set; } = null!;
    public int GuestLimit { get; set; }
    public decimal Cost { get; set; }
    public string? Description { get; set; }
}

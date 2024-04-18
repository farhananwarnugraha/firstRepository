using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoenixAPI;

public class RoomInventoryDTO
{
    public long Id { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string InventoryName { get; set; } = null!;
    public int Quantity { get; set; }
    public List<InventoryDTO>? InventoryNames { get; set; }
}

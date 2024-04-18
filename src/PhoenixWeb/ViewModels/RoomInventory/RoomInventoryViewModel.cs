namespace PhoenixWeb.ViewModels.RoomInventory;

public class RoomInventoryViewModel
{
    public long Id { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string InventoryName { get; set; } = null!;
    public int Quantity { get; set; }
    public int Stock { get; set; }
}

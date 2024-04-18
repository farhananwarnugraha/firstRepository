namespace PhoenixAPI;

public class RoomInventoryUpsertDTO
{
    public long Id { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string InventoryName { get; set; } = null!;
    public int Quantity { get; set; }
    public List<InventoryDTO>? InventoryNames { get; set; }
}

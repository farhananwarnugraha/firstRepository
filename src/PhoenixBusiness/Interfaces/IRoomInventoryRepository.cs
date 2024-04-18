using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IRoomInventoryRepository
{
    List<RoomInventory> Get(int pageNumber, int pageSize, string roomNumber);
    List<RoomInventory> Get(string roomNumber);
    RoomInventory GetRoomInventory(long idInventory);
    int Count(string roomNumber);
    void Insert(RoomInventory model);
    void Delete(RoomInventory model);

}

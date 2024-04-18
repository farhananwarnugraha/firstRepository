using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IRoomRepository
{
    List<Room> Get(int pageNumber, int pageSize,string roomNumber, string roomType);
    int Count(string roomNumber, string roomType);
    int Count(string roomNumber);
    Room Get(string roomNumber);
    void Insert(Room model);
    void Update(Room model);
    void Delete(Room model);
}

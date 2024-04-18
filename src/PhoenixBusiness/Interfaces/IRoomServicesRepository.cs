using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IRoomServicesRepository
{
    List<RoomService> Get(int pageNumber, int pageSize, string employeeNumber ,string fullName);
    int Count(string employeeNumber, string fullName);
    RoomService Get(string employeeNumber);
    void Insert(RoomService model);
    void Update(RoomService model);
    

}

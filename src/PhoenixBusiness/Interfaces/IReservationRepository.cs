using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IReservationRepository
{
    List<Reservation> Get(int pageNumber, int pageSize, string roomNumber, string gusetNumber);
    int Count();
    bool CheckRoomBooked(string roomNumber);
    void Insert(Reservation model);

}

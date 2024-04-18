using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class RservationRepository : IReservationRepository
{
    private readonly PhoenixContext _dbContext;

    public RservationRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool CheckRoomBooked(string roomNumber)
    {
        return _dbContext.Reservations
                .Any(rsv => rsv.RoomNumber == roomNumber && rsv.CheckOut >= DateTime.Now);
    }

    public int Count()
    {
        return _dbContext.Reservations.Count();
    }

    public List<Reservation> Get(int pageNumber, int pageSize, string roomNumber, string guestNumber)
    {
        var model = _dbContext.Reservations
                    .Where(
                        reservation => reservation.RoomNumber.ToLower().Contains(roomNumber??"".ToLower()) &&
                        reservation.GuestNumber.ToLower().Contains(guestNumber??"".ToLower())  
                    )
                    .Skip((pageNumber*1)-pageNumber)
                    .Take(pageSize);
        return model.ToList();
    }

    public void Insert(Reservation model)
    {
        _dbContext.Reservations.Add(model);
        _dbContext.SaveChanges();
    }
}

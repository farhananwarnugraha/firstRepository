using Microsoft.EntityFrameworkCore;
using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class RoomRepository : IRoomRepository
{
    private readonly PhoenixContext _dbContext;

    public RoomRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Count(string roomNumber, string roomType)
    {
        return _dbContext.Rooms
                .Where(
                    room => room.Number == roomNumber &&
                    room.RoomType == roomType
                ).Count();
    }

    public int Count(string roomNumber)
    {
        return _dbContext.Rooms
                .Where(
                    room => room.Number == roomNumber 
                ).Count();
    }

    public void Delete(Room model)
    {
        _dbContext.Rooms.Remove(model);
        _dbContext.SaveChanges();
    }

    public List<Room> Get(int pageNumber, int pageSize, string roomNumber, string roomType)
    {
        var model = _dbContext.Rooms
                    .Where(
                        room => room.Number.ToLower().Contains(roomNumber??"".ToLower()) &&
                        roomType != "" ? room.RoomType == roomType : true
                    )
                    .Include(room => room.Reservations)
                    .Skip((pageNumber-1)*pageSize)
                    .Take(pageSize);
        return model.ToList();
    }

    public Room Get(string roomNumber)
    {
        return _dbContext.Rooms.Find(roomNumber)?? throw new NullReferenceException("Room Not Found");
    }

    public void Insert(Room model)
    {
        _dbContext.Rooms.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(Room model)
    {
        _dbContext.Rooms.Update(model);
        _dbContext.SaveChanges();
    }
}

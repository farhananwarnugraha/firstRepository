using Microsoft.EntityFrameworkCore;
using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class RoomInventoryRepository : IRoomInventoryRepository
{
    private readonly PhoenixContext _dbContext;

    public RoomInventoryRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Count(string roomNumber)
    {
        throw new NotImplementedException();
    }

    public void Delete(RoomInventory model)
    {
        _dbContext.RoomInventories.Remove(model);
        _dbContext.SaveChanges();
    }

    public List<RoomInventory> Get(int pageNumber, int pageSize, string roomNumber)
    {
        throw new NotImplementedException();
    }

    public List<RoomInventory> Get(string roomNumber)
    {
        return _dbContext.RoomInventories
                .Include(roomdetail => roomdetail.InventoryNameNavigation)
                .Where(roomdetail => roomdetail.RoomNumber == roomNumber)
                .ToList();

    }

    public RoomInventory GetRoomInventory(long idInventory)
    {
        return _dbContext.RoomInventories.Find(idInventory) ?? throw new NullReferenceException("Data Not Found");
    }

    public void Insert(RoomInventory model)
    {
        _dbContext.RoomInventories.Add(model);
        _dbContext.SaveChanges();
    }
}

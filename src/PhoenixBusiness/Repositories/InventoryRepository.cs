using System.Data;
using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class InventoryRepository : IInventoryRepository
{
    private readonly PhoenixContext _dbContext;

    public InventoryRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Count()
    {
        return _dbContext.Inventories.Count();
    }

    public void Delete(Inventory model)
    {
        _dbContext.Inventories.Remove(model);
        _dbContext.SaveChanges();
    }

    public List<Inventory> Get(int pageNumber, int pageSize)
    {
        return _dbContext.Inventories
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize)
                .ToList();
    }

    public Inventory Get(string name)
    {
        return _dbContext.Inventories.Find(name) ?? throw new NullReferenceException("Data Inventory Not Found");
    }

    public List<Inventory> Get()
    {
        return _dbContext.Inventories.ToList();
    }

    public void Insert(Inventory model)
    {
        _dbContext.Inventories.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(Inventory model)
    {
        _dbContext.Inventories.Update(model);
        _dbContext.SaveChanges();
    }
}

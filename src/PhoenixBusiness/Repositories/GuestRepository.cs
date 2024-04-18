using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class GuestRepository : IGuestRepository
{
    private readonly PhoenixContext _dbContext;

    public GuestRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Guest> Get()
    {
        return _dbContext.Guests.ToList();
    }

    public Guest Get(string username)
    {
        return _dbContext.Guests.Find(username) ?? throw new NullReferenceException("Data Not Found");
    }

    public Guest Insert(Guest model)
    {
        _dbContext.Guests.Add(model);
        _dbContext.SaveChanges();
        return model;
    }

    public Guest Update(Guest model)
    {
        _dbContext.Guests.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
}

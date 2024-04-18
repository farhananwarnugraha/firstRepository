using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class AdminRepository : IAdminRepository
{
    private PhoenixContext _dbContext;

    public AdminRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Count()
    {
        return _dbContext.Administrators.Count();
    }

    public List<Administrator> Get(int pageNumber, int pageSize)
    {
        return _dbContext.Administrators
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize).ToList();
    }

    public Administrator Get(string username)
    {
        return _dbContext.Administrators.Find(username)?? throw new NullReferenceException("Data Not Found");
    }

    public void Insert(Administrator model)
    {
        _dbContext.Administrators.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(Administrator model)
    {
        _dbContext.Administrators.Update(model);
        _dbContext.SaveChanges();
    }
}

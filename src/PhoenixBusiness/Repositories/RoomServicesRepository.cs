using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public class RoomServicesRepository : IRoomServicesRepository
{
    private readonly PhoenixContext _dbContext;

    public RoomServicesRepository(PhoenixContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Count(string employeeNumber, string fullName)
    {
        return  _dbContext.RoomServices
                .Where(
                    rs => rs.EmployeeNumber.ToLower().Contains(employeeNumber??"".ToLower()) &&
                    (rs.FirstName + rs.MiddleName + rs.LastName).ToLower().Contains(fullName??"".ToLower())
                )
                .Count();
    }

    public List<RoomService> Get(int pageNumber, int pageSize, string employeeNumber, string fullName)
    {
        return _dbContext.RoomServices
                .Where(
                    rs => rs.EmployeeNumber.ToLower().Contains(employeeNumber??"".ToLower()) &&
                    (rs.FirstName + rs.MiddleName + rs.LastName).ToLower().Contains(fullName??"".ToLower())
                )
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize)
                .ToList();
    }

    public RoomService Get(string employeeNumber)
    {
        return _dbContext.RoomServices.Find(employeeNumber) ?? throw new NullReferenceException("Employee Data Not Found");
    }

    public void Insert(RoomService model)
    {
        _dbContext.RoomServices.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(RoomService model)
    {
        _dbContext.RoomServices.Update(model);
        _dbContext.SaveChanges();
    }
}

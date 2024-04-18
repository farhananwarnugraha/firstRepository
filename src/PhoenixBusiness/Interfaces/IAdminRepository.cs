using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IAdminRepository
{
    List<Administrator> Get(int pageNumber, int pageSize);
    Administrator Get(string username);
    int Count();
    void Update(Administrator model);
    void Insert(Administrator model);
}

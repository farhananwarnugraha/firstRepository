using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IInventoryRepository
{
    List<Inventory> Get(int pageNumber, int pageSize);
    List<Inventory> Get();
    Inventory Get(string name);
    int Count();
    void Insert(Inventory model);
    void Update(Inventory model);
    void Delete(Inventory model);
}

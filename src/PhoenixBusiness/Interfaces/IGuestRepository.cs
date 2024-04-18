using PhoenixDataAccess.Models;

namespace PhoenixBusiness;

public interface IGuestRepository
{
    List<Guest> Get();
    Guest Get(string username);
    Guest Insert(Guest model);
    Guest Update(Guest model);
}

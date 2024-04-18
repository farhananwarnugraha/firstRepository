using PhoenixBusiness;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.Inventory;

namespace PhoenixWeb;

public class InventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public InventoryIndexViewModel Get(int pageNumber, int pageSize){
        var model = _repository.Get(pageNumber, pageSize)
                    .Select(
                        inventory => new InventoryViewModel(){
                            Name = inventory.Name,
                            Stock = inventory.Stock,
                            Description = inventory.Description
                        }
                    );
        return new InventoryIndexViewModel(){
            Inventories = model.ToList(),
            Paginations = new PaginatinViewModel(){
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalData = _repository.Count()
            }
        };
    }
}

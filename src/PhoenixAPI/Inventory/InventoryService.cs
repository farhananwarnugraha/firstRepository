using PhoenixBusiness;
using PhoenixDataAccess.Models;

namespace PhoenixAPI;

public class InventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public void Insert(InventoryDTO inventoryDTO){
        var model = new Inventory(){
            Name = inventoryDTO.Name,
            Stock =  inventoryDTO.Stock,
            Description = inventoryDTO.Description
        };
        _repository.Insert(model);
    }

    public InventoryDTO Get(string name){
        var model = _repository.Get(name);
        return new InventoryDTO(){
            Name = model.Name,
            Stock = model.Stock,
            Description = model.Description
        };
    }

    public void Update(InventoryDTO inventoryDTO){
        var model = new Inventory(){
            Name = inventoryDTO.Name,
            Stock = inventoryDTO.Stock,
            Description = inventoryDTO.Description
        };
        _repository.Update(model);
    }

    public void Delete(string name){
        var model = _repository.Get(name);
        _repository.Delete(model);
    }
}

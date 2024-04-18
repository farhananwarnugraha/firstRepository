using PhoenixBusiness;
using PhoenixDataAccess.Models;

namespace PhoenixAPI;

public class RoomInventoryService
{
    public readonly IRoomInventoryRepository _roomInventoryRepository;
    public readonly IInventoryRepository _inventoryRepository;
    public readonly IRoomRepository _roomRepository;

    public RoomInventoryService(IRoomInventoryRepository roomInventoryRepository, IInventoryRepository inventoryRepository, IRoomRepository roomRepository)
    {
        _roomInventoryRepository = roomInventoryRepository;
        _inventoryRepository = inventoryRepository;
        _roomRepository = roomRepository;
    }

    public void Insert(RoomInventoryDTO viewModel){
     
            var model = new RoomInventory(){
            RoomNumber = viewModel.RoomNumber,
            InventoryName = viewModel.InventoryName,
            Quantity = viewModel.Quantity
            };

            var inventory = _inventoryRepository.Get(viewModel.InventoryName);

            if(inventory.Stock > 0){
                inventory.Stock -= model.Quantity;

                _roomInventoryRepository.Insert(model);
                _inventoryRepository.Update(inventory);
            }
    }

    public RoomInventoryDTO Add(string roomNumber){
        return new RoomInventoryDTO(){
            InventoryNames = _inventoryRepository.Get()
                            .Where(inventory => inventory.Stock >0)
                            .Select(inventory => new InventoryDTO(){
                                Name = inventory.Name.Trim(),
                                Stock = inventory.Stock,
                                Description = inventory.Description.Trim()
                            } 
                            ).ToList(),
            RoomNumber = _roomRepository.Get(roomNumber).Number 
        }; 
    }

    public void Delete(long idInventory){
        var model = _roomInventoryRepository.GetRoomInventory(idInventory);
        _roomInventoryRepository.Delete(model);
    }
}

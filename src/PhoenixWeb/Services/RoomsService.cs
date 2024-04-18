using System.Globalization;
using PhoenixBusiness;
using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.Room;
using PhoenixWeb.ViewModels.RoomInventory;

namespace PhoenixWeb;

public class RoomsService
{
    private readonly IRoomRepository _repositroy;
    private readonly IReservationRepository _repositoryReservation;
    private readonly IRoomInventoryRepository _roomInventoryRepository;

    public RoomsService(IRoomRepository repositroy, IReservationRepository repositoryReservation, IRoomInventoryRepository roomInventoryRepository)
    {
        _repositroy = repositroy;
        _repositoryReservation = repositoryReservation;
        _roomInventoryRepository = roomInventoryRepository;
    }

    public RoomIndexViewModel Get(int pageNumber, int pageSize, string roomNumber, string roomType){
        var model = _repositroy.Get(pageNumber, pageSize, roomNumber, roomType)
                    .Select(
                        room => new RoomViewModel(){
                            Number = room.Number,
                            Floor = room.Floor,
                            RoomType = room.RoomType,
                            GuestLimit = room.GuestLimit,
                            Cost = room.Cost,
                            Status = _repositoryReservation.CheckRoomBooked(room.Number)?"Booked" : "Vacant"
                        }
                    );
        return new RoomIndexViewModel(){
            Rooms = model.ToList(),
            Paginations = new PaginatinViewModel(){
                PageNumber = pageNumber, 
                PageSize = pageSize,
                TotalData = _repositroy.Count(roomNumber, roomType)
            },
            RoomNumber = roomNumber??"",
            RoomType = roomType??""
        };
    }

    public RoomUpsertViewModel GetForm(){
        return new RoomUpsertViewModel();
    }

    public void Insert(RoomUpsertViewModel vieModel){
        var model = new Room(){
            Number = vieModel.Number,
            Floor = vieModel.Floor,
            RoomType = vieModel.RoomType,
            GuestLimit = vieModel.GuestLimit,
            Cost = vieModel.Cost,
            Description = vieModel.Description
        };
        _repositroy.Insert(model);
    }

    public RoomUpsertViewModel Get(string roomNumber){
        var model = _repositroy.Get(roomNumber);
        return new RoomUpsertViewModel(){
            Number = model.Number,
            Floor = model.Floor,
            RoomType = model.RoomType,
            GuestLimit = model.GuestLimit,
            Cost = model.Cost,
            Description = model.Description
        };
    }

    public void Update(RoomUpsertViewModel viewModel){
        var model = new Room(){
            Number = viewModel.Number.Trim(),
            Floor = viewModel.Floor,
            RoomType = viewModel.RoomType,
            GuestLimit = viewModel.GuestLimit,
            Cost = viewModel.Cost,
            Description = viewModel.Description
        };
        _repositroy.Update(model);
    }

    public RoomDetailViewModel GetDetailRoom(string roomNumber){
        var roomModel = _repositroy.Get(roomNumber);
        var itemRoom = _roomInventoryRepository.Get(roomNumber)
                        .Select(
                            roominventory => new RoomInventoryViewModel(){
                                Id = roominventory.Id,
                                RoomNumber = roominventory.RoomNumber,
                                InventoryName = roominventory.InventoryName,
                                Quantity = roominventory.Quantity,
                                Stock = roominventory.InventoryNameNavigation.Stock
                            }
                        );
        return new RoomDetailViewModel(){
            Number = roomModel.Number,
            Floor = roomModel.Floor,
            RoomType = roomModel.RoomType,
            GuestLimit = roomModel.GuestLimit,
            RoomInventories = itemRoom.ToList()
        }; 
    }

    public DetailRoomViewModel DetailRoom(string roomNumber){
        var model = _repositroy.Get(roomNumber);
        return new DetailRoomViewModel(){
            Number = model.Number,
            Floor = model.Floor,
            RoomType = model.RoomType,
            GuestLimit = model.GuestLimit,
            Cost = model.Cost,
            Description = model.Description
        };
    }
}

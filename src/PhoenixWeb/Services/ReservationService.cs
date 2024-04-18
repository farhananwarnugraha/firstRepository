using System.Globalization;
using PhoenixBusiness;
using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.Reservation;
using PhoenixWeb.ViewModels.Room;

namespace PhoenixWeb;

public class ReservationService
{
    private readonly IReservationRepository _repository;
    private readonly IRoomRepository _repositoryRoom;

    public ReservationService(IReservationRepository repository, IRoomRepository repositoryRoom)
    {
        _repository = repository;
        _repositoryRoom = repositoryRoom;
    }

    public RservationIndexViewModel Get(int pageNumber, int pageSize, string roomNumber, string guestNumber){
        var model = _repository.Get(pageNumber, pageSize, guestNumber, roomNumber)
                    .Select(
                        reservation => new ReservationViewModel(){
                            Code = reservation.Code,
                            RoomNumber = reservation.RoomNumber,
                            GuestNumber = reservation.GuestNumber,
                            BookDate = reservation.BookDate,
                            CheckIn = reservation.CheckIn,
                            CheckOut = reservation.CheckOut,
                            PaymentDate = reservation.PaymentDate
                        }
                    );
        return new RservationIndexViewModel(){
            Reservations = model.ToList(),
            Paginations = new PaginatinViewModel(){
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalData = _repository.Count()
            }
        };
    }

   public MakeReservationViewModel Get(string roomNumber){
        var roomModel = _repositoryRoom.Get(roomNumber);
        return new MakeReservationViewModel(){
            DetailRooms = new DetailRoomViewModel(){
                Number = roomModel.Number,
                Floor = roomModel.Floor,
                RoomType = roomModel.RoomType,
                GuestLimit = roomModel.GuestLimit,
                Cost = roomModel.Cost
            }
        };
   }

   public void Insert(string guestNumber, MakeReservationViewModel viewModel){
        var totalReservation = _repositoryRoom.Count(viewModel.DetailRooms.Number);
        totalReservation =+1;
        var model = new Reservation(){
            Code = $"{viewModel.DetailRooms.Number}-{DateTime.Now.ToString("dd")}-{DateTime.Now.ToString("mm")}-{DateTime.Now.ToString("yyyy")}-{totalReservation.ToString().PadLeft(3, '0')}",
            ReservationMethod = viewModel.ReservationMethod,
            RoomNumber = viewModel.DetailRooms.Number,
            GuestNumber = guestNumber,
            BookDate = DateTime.Now,
            CheckIn = viewModel.CheckIn,
            CheckOut = viewModel.CheckOut,
            Cost = viewModel.Cost,
            PaymentDate = DateTime.Now,
            PaymentMethod = viewModel.PaymentMethod,
            Remark = viewModel.Remark
        };
        _repository.Insert(model);
   }
}

using PhoenixBusiness;
using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.RoomServices;

namespace PhoenixWeb;

public class RoomServicesService
{
    private readonly IRoomServicesRepository _repository;

    public RoomServicesService(IRoomServicesRepository repository)
    {
        _repository = repository;
    }

    public RoomServicesIndexViewModel Get(int pageNumber, int pageSize, string employeeNumber, string fullName){
        var model = _repository.Get(pageNumber,pageSize,employeeNumber,fullName)
                    .Select(
                        rs => new RoomServicesViewModel(){
                            EmployeeNumber = rs.EmployeeNumber,
                            FullName = $"{rs.FirstName} {rs.MiddleName} {rs.LastName}",
                            OutsourcingCompany = rs.OutsourcingCompany
                        }
                    );
        return new RoomServicesIndexViewModel(){
            Employees = model.ToList(),
            Paginations = new PaginatinViewModel(){
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalData = _repository.Count(employeeNumber,fullName)
            },
            EmployeeNumber = employeeNumber,
            FullName = fullName
        };
    } 

    public DetailRoomServiceViewModel GetDetail(string employeeNumber){
        var model = _repository.Get(employeeNumber);
        return new DetailRoomServiceViewModel(){
            DetailRoomService = new RoomServicesViewModel(){
                EmployeeNumber = model.EmployeeNumber,
                FullName = $"{model.FirstName} {model.MiddleName} {model.LastName}",
                OutsourcingCompany = model.OutsourcingCompany
            },
            MondayRoasterStart = model.MondayRoasterStart,
            MondayRoasterFinish = model.MondayRoasterFinish,
            TuesdayRoasterStart = model.TuesdayRoasterStart,
            TuesdayRoasterFinish = model.TuesdayRoasterFinish,
            WednesdayRoasterStart = model.WednesdayRoasterStart,
            WednesdayRoasterFinish = model.WednesdayRoasterFinish,
            ThursdayRoasterStart = model.ThursdayRoasterStart,
            ThursdayRoasterFinish = model.ThursdayRoasterFinish,
            FridayRoasterStart = model.FridayRoasterStart,
            FridayRoasterFinish = model.FridayRoasterFinish,
            SaturdayRoasterStart = model.SaturdayRoasterStart,
            SaturdatRoasterFinish = model.SaturdatRoasterFinish,
            SundayRoasterStart = model.SundayRoasterStart,
            SundayRoasterFinish = model.SundayRoasterFinish
        };
    }

    public void Update(string employeeNumber,DetailRoomServiceViewModel viewModel){
        var employee = _repository.Get(employeeNumber);
            employee.MondayRoasterStart = viewModel.MondayRoasterStart;
            employee.MondayRoasterFinish = viewModel.MondayRoasterFinish;
            employee.TuesdayRoasterStart = viewModel.TuesdayRoasterStart;
            employee.TuesdayRoasterFinish = viewModel.TuesdayRoasterFinish;
            employee.WednesdayRoasterStart = viewModel.WednesdayRoasterStart;
            employee.WednesdayRoasterFinish = viewModel.WednesdayRoasterFinish;
            employee.ThursdayRoasterStart = viewModel.ThursdayRoasterStart;
            employee.ThursdayRoasterFinish = viewModel.ThursdayRoasterFinish;
            employee.FridayRoasterStart = viewModel.FridayRoasterStart;
            employee.FridayRoasterFinish = viewModel.FridayRoasterFinish;
            employee.SaturdayRoasterStart = viewModel.SaturdayRoasterStart;
            employee.SaturdatRoasterFinish = viewModel.SaturdatRoasterFinish;
            employee.SundayRoasterStart = viewModel.SundayRoasterStart;
            employee.SundayRoasterFinish = viewModel.SundayRoasterFinish;
        _repository.Update(employee);
    }
}

using PhoenixBusiness;
using PhoenixDataAccess.Models;

namespace PhoenixAPI;

public class RsService
{
    private readonly IRoomServicesRepository _repository;

    public RsService(IRoomServicesRepository repository)
    {
        _repository = repository;
    }

    public void Insert(RoomServiceDTO dto){
        var model = new RoomService(){
            EmployeeNumber = dto.EmployeeNumber,
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            OutsourcingCompany = dto.OutsourcingCompany
        };
        _repository.Insert(model);
    }

    public RoomService Get(string employeeNumber){
        var model = _repository.Get(employeeNumber);
        return new RoomService(){
            EmployeeNumber = model.EmployeeNumber.Trim(),
            FirstName = model.FirstName.Trim(),
            MiddleName = model.MiddleName?.Trim(),
            LastName = model.LastName?.Trim(),
            OutsourcingCompany = model.OutsourcingCompany.Trim()
        };
    }

    public void Update(RoomServiceDTO dto){
        var model = new RoomService(){
            EmployeeNumber = dto.EmployeeNumber,
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            OutsourcingCompany = dto.OutsourcingCompany
        };
        _repository.Update(model);
    }
}

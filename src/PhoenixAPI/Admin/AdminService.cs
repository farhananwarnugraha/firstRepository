using PhoenixBusiness;
using PhoenixDataAccess.Models;

namespace PhoenixAPI;

public class AdminService
{
    private readonly IAdminRepository _repository;

    public AdminService(IAdminRepository repository)
    {
        _repository = repository;
    }

    public AdminDTO Get(string Username){
        var model = _repository.Get(Username);
        return new AdminDTO(){
            Username = model.Username.Trim(),
            JobTitle = model.JobTitle.Trim(),
            Password = model.Password.Trim()
        };
    }

    public void Update(AdminDTO adminDTO){
        var model = new Administrator(){
            Username = adminDTO.Username.Trim(), 
            JobTitle = adminDTO.JobTitle.Trim(),
            Password = adminDTO.Password.Trim()
        };
        _repository.Update(model);
    }

    
}

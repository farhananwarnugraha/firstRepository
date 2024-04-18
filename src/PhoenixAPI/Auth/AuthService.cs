using PhoenixBusiness;
using PhoenixDataAccess.Models;

namespace PhoenixAPI;

public class AuthService
{
    private readonly IAdminRepository _adminRepository;

    public AuthService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public AuthRegisterDTO GetRegister(){
        return new AuthRegisterDTO();
    }

    public void SetRegister(AuthRegisterDTO viewModel){
        var model = new Administrator(){
            Username = viewModel.Username,
            Password = BCrypt.Net.BCrypt.HashPassword("default1234"),
            JobTitle = viewModel.JobTitle
        };
        _adminRepository.Insert(model);
    }
}

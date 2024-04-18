using PhoenixBusiness;

namespace PhoenixAPI;

public class AccountService
{
    private readonly IAdminRepository _repository;

    public AccountService(IAdminRepository repository)
    {
        _repository = repository;
    }

    public void ChangePassword(string username, ChangePasswordDTO dto){
        var model = _repository.Get(username);
        var checkOldPassword = BCrypt.Net.BCrypt.Verify(dto.OldPassword, model.Password);
        if(!checkOldPassword) throw new NullReferenceException("Old Password Incorrect");
        model.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
        _repository.Update(model);
    }
}

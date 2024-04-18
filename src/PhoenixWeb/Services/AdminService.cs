using PhoenixBusiness;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.Admin;

namespace PhoenixWeb;

public class AdminService
{
    private readonly IAdminRepository _repository;

    public AdminService(IAdminRepository repository)
    {
        _repository = repository;
    }

    public AdminIndexViewModel Get(int pageNumber, int pageSize){
        var model = _repository.Get(pageNumber, pageSize)
                    .Select(
                        admin => new AdminViewModel(){
                            Username = admin.Username,
                            JobTitle = admin.JobTitle
                        }
                    );
        return new AdminIndexViewModel(){
            Administrators = model.ToList(),
            Paginations = new PaginatinViewModel(){
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalData = _repository.Count()
            }
        };
    }
}

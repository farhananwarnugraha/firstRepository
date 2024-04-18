namespace PhoenixWeb.ViewModels.RoomServices;

public class RoomServicesIndexViewModel
{
    public List<RoomServicesViewModel> Employees { get; set; }
    public PaginatinViewModel Paginations { get; set; }
    public string EmployeeNumber { get; set; }
    public string FullName { get; set; }
}

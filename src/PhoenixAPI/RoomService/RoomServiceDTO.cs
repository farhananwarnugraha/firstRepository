namespace PhoenixAPI;

public class RoomServiceDTO
{
    public string EmployeeNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string OutsourcingCompany { get; set; } = null!;
}

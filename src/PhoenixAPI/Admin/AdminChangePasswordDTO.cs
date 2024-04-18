namespace PhoenixAPI;

public class AdminChangePasswordDTO
{
    public string OldPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
    public string ConfirmNewPassword { get; set; } = null!;

}

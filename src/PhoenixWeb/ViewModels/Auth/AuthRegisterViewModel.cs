using System.ComponentModel.DataAnnotations;

namespace PhoenixWeb.ViewModels.Auth;

public class AuthRegisterViewModel
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
    [Required]
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public DateTime BirthDate { get; set; } 
    [Required]
    public string Gender { get; set; } = null!;
    [Required]
    public string Citizenship { get; set; } = null!;
    [Required]
    public string IdNumber { get; set; } = null!;
}

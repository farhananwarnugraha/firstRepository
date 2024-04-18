using System.Security.Claims;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoenixBusiness;
using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels.Auth;

namespace PhoenixWeb;

public class AuthService : Controller
{
    private readonly IGuestRepository _reposiitory;
    private readonly IAdminRepository _adminRepository;

    public AuthService(IGuestRepository reposiitory, IAdminRepository adminRepository)
    {
        _reposiitory = reposiitory;
        _adminRepository = adminRepository;
    }

    private ClaimsPrincipal GetPrincipal(AuthLoginViewModel viewModel){
       List<Claim> claims;
        if(viewModel.Role == "Administrator"){
            claims = new List<Claim>{
            new Claim("username", viewModel.Username),
            new Claim(ClaimTypes.Role, viewModel.Role??""),
            new Claim("jobTitle", viewModel.JobTitle??"")

            };
        }else{
            claims = new List<Claim>{
                new Claim("username", viewModel.Username),
                new Claim(ClaimTypes.Role, viewModel.Role)
            };
        }
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }

    private AuthenticationTicket GetTicket(ClaimsPrincipal principal){
        AuthenticationProperties authenticationProperties = new AuthenticationProperties(){
            IssuedUtc = DateTime.Now,
            ExpiresUtc = DateTime.Now.AddMinutes(10),
            AllowRefresh = false
        };
        AuthenticationTicket authenticationTicket = new AuthenticationTicket(
            principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme
        );
        return authenticationTicket;
    }

    public AuthenticationTicket SetLogin(AuthLoginViewModel viewModel){
        if(viewModel.Role == "Administrator"){
            var modelAdmin = _adminRepository.Get(viewModel.Username);
            bool adminPasswordCorrection = BCrypt.Net.BCrypt.Verify(viewModel.Password, modelAdmin.Password.Trim());
            if(!adminPasswordCorrection)
                throw new NullReferenceException("Username or Passord do not match");
            viewModel = new AuthLoginViewModel(){
                Username = modelAdmin.Username,
                Role = viewModel.Role,
                Password = modelAdmin.Password,
                JobTitle = modelAdmin.JobTitle
            
            };
            ClaimsPrincipal principal = GetPrincipal(viewModel);
            AuthenticationTicket ticket = GetTicket(principal);
            return ticket;
        }else{
            var model = _reposiitory.Get(viewModel.Username);
            bool passwordCorrection = BCrypt.Net.BCrypt.Verify(viewModel.Password, model.Password.Trim());
            if(!passwordCorrection)
                throw new NullReferenceException("Username or Password do not match");
            viewModel = new AuthLoginViewModel(){
                Username = model.Username,
                Role = viewModel.Role,
                Password = model.Password,
                
            };
            ClaimsPrincipal principal = GetPrincipal(viewModel);
            AuthenticationTicket ticket = GetTicket(principal);
            return ticket;
        }
    }

    private List<SelectListItem> AddRoles(){
        return new List<SelectListItem>(){
            new SelectListItem(){
                Text = "Administrator",
                Value = "Administrator"
            },
            new SelectListItem(){
                Text = "Guest",
                Value = "Guest"
            }
        };
    }

    public AuthLoginViewModel GetLogin(){
        return new AuthLoginViewModel(){
            Roles = AddRoles()
        };
    }

    //for register Guest
    public AuthRegisterViewModel GetRegisterViewModel(){
        return new AuthRegisterViewModel();
    }

    public void GuestRegister(AuthRegisterViewModel viewModel){
        var model = new Guest(){
            Username = viewModel.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(viewModel.Password),
            FirstName = viewModel.FirstName,
            MiddleName = viewModel.MiddleName,
            LastName = viewModel.LastName,
            BirthDate = viewModel.BirthDate,
            Gender = viewModel.Gender,
            Citizenship = viewModel.Citizenship, 
            IdNumber = viewModel.IdNumber
        };
        _reposiitory.Insert(model);
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PhoenixWeb.ViewModels.Auth;

namespace PhoenixWeb;

public class AuthController : Controller
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index(string? messaage){
        ViewBag.Error = messaage;
        var vm = _service.GetLogin();
        return View("Index", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Index(AuthLoginViewModel viewModel){
        if(ModelState.IsValid){
            try
            {
                var ticket = _service.SetLogin(viewModel);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    ticket.Principal,
                    ticket.Properties
                );
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction("Index", new {messaage= e.Message});
            }  
        }
        return View();
    }

    [HttpGet]
    public IActionResult Register(){
        if(User?.Identity?.IsAuthenticated??false)
            return RedirectToAction("Index");
        var viewModel = _service.GetRegisterViewModel();
        return View("RegisterGuest", viewModel);
    } 

    [HttpPost]
    public IActionResult Register(AuthRegisterViewModel viewModel){
        if(ModelState.IsValid){
            _service.GuestRegister(viewModel);
            return RedirectToAction("Index");
        }
        var vm = _service.GetRegisterViewModel();
        return View("RegisterGuest",vm);
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index");
    }
}

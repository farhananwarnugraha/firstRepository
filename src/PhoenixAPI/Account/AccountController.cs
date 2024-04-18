using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace PhoenixAPI;

public class AccountController : ControllerBase
{
   private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut]
    public IActionResult ChangePassword(ChangePasswordDTO dto){
        try
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value??"";
            _accountService.ChangePassword(user, dto);
            return Ok("Change Password Done");           
        }
        catch (Exception e)
        {
            var error = e.Message;
            return BadRequest(error);
        }
    }
}

using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IEmailService _service):ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> SendEmail()
    {
        await _service.SendEmailConfirmation();
        return Content("Email sended"); 
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> VerifyAccount(string token)
    {
        await _service.AccountVerify(token);
        return Content("Email confirmed"); 
    }
}
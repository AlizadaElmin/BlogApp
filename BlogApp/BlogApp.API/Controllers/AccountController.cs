using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IEmailService _service):ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Verify(string username)
    {
        await _service.SendEmailConfirmation(username);
        return Content("Email sended"); 
    }
}
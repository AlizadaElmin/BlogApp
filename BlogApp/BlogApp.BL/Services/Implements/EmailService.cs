// using System.Net;
// using System.Net.Mail;
// using System.Security.Claims;
// using BlogApp.BL.DTOs.Options;
// using BlogApp.BL.Exceptions.Common;
// using BlogApp.BL.Services.Interfaces;
// using BlogApp.Core.Entities;
// using BlogApp.Core.Repositories;
// using BlogApp.DAL.Repositories;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Options;
//
// namespace BlogApp.BL.Services.Implements;
//
// public class EmailService:IEmailService
// {
//     readonly SmtpClient _client;
//     readonly MailAddress _from;
//     readonly HttpContext _context;
//     readonly IUserRepository _repo;
//     // readonly UserManager<User> _userManager;
//     
//     public EmailService(IOptions<EmailOptions> options,IHttpContextAccessor acc,IUserRepository userRepo)
//     {
//         var opt = options.Value;
//         _client = new(opt.Host, opt.Port);
//         _client.Credentials = new NetworkCredential(opt.Sender, opt.Password);
//         _client.EnableSsl = true;
//         _from = new MailAddress(opt.Sender,"Elmin");
//         _context = acc.HttpContext;
//         _repo = userRepo;
//     }
//     public async Task SendEmailConfirmation(string name)
//     {
//         User? user =  await _repo.GetByUserNameAsync(name);
//         if (user == null)
//             throw new NotFoundException<User>();
//         MailAddress to = new(user.Email);
//         MailMessage msg = new(_from, to);
//         msg.Subject = "Confirm your email address";
//         msg.IsBodyHtml = true;
//         await _client.SendMailAsync(msg);
//         user.Role = 1;
//         await  _repo.SaveAsync();
//     }
// }
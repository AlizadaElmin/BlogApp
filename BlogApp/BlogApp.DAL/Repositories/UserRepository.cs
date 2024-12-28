using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories;

public class UserRepository :GenericRepository<User>,IUserRepository
{
    private readonly HttpContext _httpContext;
    readonly BlogDbContext _context;
    public UserRepository(BlogDbContext context,IHttpContextAccessor httpContext):base(context)
    {
        _httpContext = httpContext.HttpContext;
        _context = context;
    }
    public User GetCurrentUser()
    {
        return new();
    }

    public int GetCurrentUserId()
    {
        return 0;
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        return await _context.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
    }
}
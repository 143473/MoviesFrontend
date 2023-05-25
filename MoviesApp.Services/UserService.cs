using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services;

public class UserService : IUserService
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserService(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public string GetUserId()
    {
        return _signInManager.Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public string GetUserName()
    {
        var name = _signInManager.Context.User.Identity?.Name;
        if (name == null)
        {
           return string.Empty;
        }
        string[] parts = name.Split(new[]{ '@' });
        name = parts[0];
        return name;
    }
}
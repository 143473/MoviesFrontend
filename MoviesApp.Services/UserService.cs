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
}
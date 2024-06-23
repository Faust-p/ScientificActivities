using Microsoft.AspNetCore.Mvc;
using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.ModelRequest.UserActivity;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class UserController : BaseController<User, UserRequest, IUserService>
{
    private readonly IUserService _userService;
    public UserController(IUserService service, IUserService userService) : base(service)
    {
        _userService = userService;
    }
    
    [HttpPost("Login")]
    public async Task<Token> Login(UserLoginRequest entityRequest)
    {
        return await _userService.LoginAsync(entityRequest ,new CancellationToken());
    }
}
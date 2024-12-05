using System.Threading.Tasks;
using CMPS411_FA2024_Stitched_Diamonds.Common;
using CMPS411_FA2024_Stitched_Diamonds.Entities;
using CMPS411_FA2024_Stitched_Diamonds.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMPS411_FA2024_Stitched_Diamonds.Controllers;

[ApiController]
[Route("/api")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signInManager;

    public AuthenticationController(
        IAuthenticationService authenticationService,
        UserManager<Account> userManager,
        SignInManager<Account> signInManager)
    {
        _authenticationService = authenticationService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginDto dto)
    {
        var response = new Response();

        var user = await _userManager.FindByNameAsync(dto.UserName ?? "");

        if (user == null)
        {
            response.AddError(string.Empty, "Username or password is incorrect");
            return BadRequest(response);
        }

        var result = await _signInManager.PasswordSignInAsync(
            dto.UserName,
            dto.Password,
            false,
            false);

        if (!result.Succeeded)
        {
            response.AddError(string.Empty, "Username or password is incorrect");
            return BadRequest(response);
        }

        response.Data = result.Succeeded;
        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [Authorize]
    [HttpGet("get-current-user")]
    public IActionResult GetLoggedInUser()
    {
        var response = new Response();
        var user = _authenticationService.GetLoggedInUser();

        if (user == null)
        {
            response.AddError(string.Empty, "There was an issue getting the logged in user.");
            return NotFound(response);
        }

        var userGetDto = new UserGetDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Nickname = user.Nickname,
            DateCreated = user.DateCreated,
            Avatar = user.Avatar,
        };

        response.Data = userGetDto;

        return Ok(response);
    }
}

public class LoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
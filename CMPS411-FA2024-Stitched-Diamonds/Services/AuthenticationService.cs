using System.Linq;
using System.Security.Claims;
using IdentityModel;
using CMPS411_FA2024_Stitched_Diamonds.Data;
using CMPS411_FA2024_Stitched_Diamonds.Entities;
using Microsoft.AspNetCore.Http;

namespace CMPS411_FA2024_Stitched_Diamonds.Services;

public interface IAuthenticationService
{
    Account GetLoggedInUser();
}

public class AuthenticationService : IAuthenticationService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationService(
        DataContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public Account GetLoggedInUser()
    {
        if (!IsUserLoggedIn())
            return null;

        var id = RequestingUser.FindFirstValue(JwtClaimTypes.Subject).SafeParseInt();

        return id == null
            ? null
            : _context.Accounts.SingleOrDefault(x => x.Id == id.Value);
    }

    private ClaimsPrincipal RequestingUser
    {
        get
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var identity = httpContext?.User.Identity;

            if (identity == null)
            {
                return null;
            }

            return !identity.IsAuthenticated
                ? null
                : httpContext.User;
        }
    }

    private bool IsUserLoggedIn()
    {
        return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}
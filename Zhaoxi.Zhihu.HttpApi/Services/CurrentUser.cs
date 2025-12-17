using System.Security.Claims;
using Zhaoxi.Zhihu.UseCases.Common.Interfaces;

namespace Zhaoxi.Zhihu.HttpApi.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public readonly ClaimsPrincipal? User = httpContextAccessor.HttpContext?.User;

    public int? Id
    {
        get
        {
            if (User is null) return null;
            return Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
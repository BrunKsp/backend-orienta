using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Orienta.Application.Utils;

public interface IUserInfo
{
    IEnumerable<Claim> GetClaims();
}
public class UserInfo : IUserInfo
{
    private readonly IHttpContextAccessor _accessor;

    public UserInfo(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public IEnumerable<Claim> GetClaims()
    {
        return _accessor.HttpContext.User.Claims;
    }
}
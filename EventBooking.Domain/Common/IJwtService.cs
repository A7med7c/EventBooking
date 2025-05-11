using EventBooking.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace EventBooking.Domain.Common
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> CreateJwtToken(User user);
    }
}
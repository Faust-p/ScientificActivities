using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.ModelRequest.UserActivity;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Infrastructure.Providers;

public class TokenProvider : ITokenProvider
{
    private readonly IAuthOptions _authOptions;

    public TokenProvider(IAuthOptions authOptions)
    {
        _authOptions = authOptions;
    }

    public Token CreateToken(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
    
        // Validate the key length
        ValidateKeyLength(_authOptions.Key);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_authOptions.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, Convert.ToString(user.Id))
            }),
            Expires = null,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Token { Value = tokenHandler.WriteToken(token) };
    }
    
    private void ValidateKeyLength(string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        if (keyBytes.Length < 32) // 32 bytes = 256 bits
        {
            throw new ArgumentOutOfRangeException(nameof(key), "Key length must be at least 256 bits.");
        }
    }
}
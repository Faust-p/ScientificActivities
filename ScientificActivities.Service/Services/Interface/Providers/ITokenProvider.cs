using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.ModelRequest.UserActivity;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface ITokenProvider
{
    Token CreateToken(User user);
}
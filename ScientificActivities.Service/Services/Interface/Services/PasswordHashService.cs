namespace ScientificActivities.Service.Services.Interface.Services;

public interface IPasswordHashService
{
    (string Hash, string Key) GenHashPassword(string password);
    string GetHashPassword(string password, string key);
}
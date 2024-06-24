using System.Security.Cryptography;
using System.Text;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public  class PasswordHashService : IPasswordHashService
{
    public  (string Hash, string Key) GenHashPassword(string password)
    {
        var passwordKey = Guid.NewGuid().ToString("N");
        return (BitConverter.ToString(
            SHA256.Create().ComputeHash(
                Encoding.UTF8.GetBytes(password + passwordKey))), passwordKey);
    }

    public string GetHashPassword(string password, string key)
    {
        var computedHash = BitConverter.ToString(
            SHA256.Create().ComputeHash(
                Encoding.UTF8.GetBytes(password + key)));
    
        Console.WriteLine($"Computed Hash: {computedHash}");
        return computedHash;
    }
}
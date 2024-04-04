using ScientificActivities.StorageEnums;

namespace ScientificActivities.Services.DTO;

public class UserDTO
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string SureName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string PasswordKey { get; set; } = string.Empty;

    public EnumUserRole Role { get; set; } = EnumUserRole.User;

    public EnumUserStatus Status { get; set; } = EnumUserStatus.New;
    
}
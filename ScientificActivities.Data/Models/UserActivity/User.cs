using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.UserActivity;

public class User : BaseModel
{
    public User(string firstName, string lastName, string sureName, string email, EnumUserRole role, EnumUserStatus status, string passwordKey, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        SureName = sureName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordKey = passwordKey;
        Role = role;
        Status = status;
        //Tokens = new List<MailToken>();
    }

    protected User()
    {
    }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string SureName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string PasswordKey { get; set; } = string.Empty;

    public EnumUserRole Role { get; set; } = EnumUserRole.User;

    public EnumUserStatus Status { get; set; } = EnumUserStatus.New;

    //public List<MailToken> Tokens { get; set; } = null!;
}
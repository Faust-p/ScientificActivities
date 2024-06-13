namespace ScientificActivities.Service.ModelRequest.UserActivity;

public class UserRequest : BaseModelRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string SureName { get; set; }

    public string Email { get; set; }
    
    public string Role { get; set; }
    
    public string Status { get; set; }
}
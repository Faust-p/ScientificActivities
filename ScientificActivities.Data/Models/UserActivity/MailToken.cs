namespace ScientificActivities.Data.Models.UserActivity;

public class MailToken : BaseModel
{
    public DateTime DateExpire { get; set; }

    public User User { get; set; }
}
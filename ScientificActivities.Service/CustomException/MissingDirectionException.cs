namespace ScientificActivities.Service.CustomException;

public class MissingDirectionException : Exception
{
    public MissingDirectionException(string? message) : base(message)
    {
    }
}
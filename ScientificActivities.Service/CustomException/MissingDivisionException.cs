namespace ScientificActivities.Service.CustomException;

public class MissingDivisionException : Exception
{
    public MissingDivisionException(string? message) : base(message)
    {
    }
}
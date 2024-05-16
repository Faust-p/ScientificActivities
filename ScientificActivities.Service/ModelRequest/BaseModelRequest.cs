namespace ScientificActivities.Service.ModelRequest;

public abstract class BaseModelRequest
{
    public BaseModelRequest()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
namespace ScientificActivities.Service.Services.Interface.Services;

public interface IParseService
{
    Task ParseFullAsync(string url, CancellationToken cancellationToken);
}
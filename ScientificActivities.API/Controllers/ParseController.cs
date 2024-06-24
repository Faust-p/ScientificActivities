using Microsoft.AspNetCore.Mvc;
using ScientificActivities.Service.ModelRequest.Parser;
using ScientificActivities.Service.ModelRequest.UserActivity;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class ParseController : ApiBaseController
{
    private readonly IParseService _parseService;

    public ParseController(IParseService parseService)
    {
        _parseService = parseService;
    }

    [HttpPost("ParseFull")]
    public async Task ParseFull(string url)
    {
        await _parseService.ParseFullAsync(url, new CancellationToken());
    }
}
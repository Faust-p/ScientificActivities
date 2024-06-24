﻿using Microsoft.AspNetCore.Mvc;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class JournalController : BaseController<Journal, JournalRequest, IJournalService>
{
    public JournalController(IJournalService service) : base(service)
    {
    }
    
    [HttpPost("Parse")]
    public async Task<IActionResult> ParseAsync(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        var id = await _service.ParseAsync(url, new CancellationToken());
        return Ok(id);
    }
}
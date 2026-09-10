using Microsoft.AspNetCore.Mvc;
using SolarOps.Api.Modules.Operations.Services;
using SolarOps.Api.Modules.Sales.Models;

namespace SolarOps.Api.Modules.Operations.Controllers;

[ApiController]
[Route("api/operations/scheduled-visits")]
public class ScheduledVisitsController : ControllerBase
{
    private readonly ScheduledVisitService _service;

    public ScheduledVisitsController(ScheduledVisitService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Lead>>> GetScheduledVisits()
    {
        var visits = await _service.GetScheduledVisitsAsync();

        return Ok(visits);
    }
}
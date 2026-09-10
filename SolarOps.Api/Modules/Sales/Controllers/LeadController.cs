using Microsoft.AspNetCore.Mvc;
using SolarOps.Api.Modules.Sales.DTO;
using SolarOps.Api.Modules.Sales.Models;
using SolarOps.Api.Modules.Sales.Services;

namespace SolarOps.Api.Modules.Sales.Controllers;

[ApiController]
[Route("api/sales/leads")]
public class LeadController : ControllerBase
{
    private readonly LeadService _leadService;

    public LeadController(LeadService leadService)
    {
        _leadService = leadService;
    }

    [HttpPost]
    public async Task<ActionResult<Lead>> CreateLead(CreateLeadRequest request)
    {
        var lead = await _leadService.CreateLeadAsync(request);

        return Ok(lead);
    }

[HttpPost("{leadId}/schedule")]
public async Task<ActionResult> ScheduleLead(
    Guid leadId,
    ScheduleLeadRequest request)
{
    await _leadService.ScheduleLeadAsync(
        leadId,
        request.ScheduledAt);

    return Ok();
}
}
using Microsoft.AspNetCore.Mvc;
using SolarOps.Api.Modules.Operations.Models;
using SolarOps.Api.Modules.Operations.Services;

namespace SolarOps.Api.Modules.Operations.Controllers;

[ApiController]
[Route("api/operations/inspections")]
public class OperationsInspectionController : ControllerBase
{
    private readonly OperationsInspectionService _service;

    public OperationsInspectionController(OperationsInspectionService service)
    {
        _service = service;
    }

    [HttpPost("{leadId}")]
    public async Task<ActionResult<OperationsInspection>> CreateInspection(
        Guid leadId)
    {
        var inspection = await _service.CreateInspectionAsync(leadId);

        return Ok(inspection);
    }
}
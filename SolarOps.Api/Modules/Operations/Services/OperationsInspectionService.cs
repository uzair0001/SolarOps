using SolarOps.Api.Infrastructure.Data;
using SolarOps.Api.Modules.Operations.Models;
using SolarOps.Api.Modules.Sales.Models;

namespace SolarOps.Api.Modules.Operations.Services;

public class OperationsInspectionService
{
    private readonly SolarOpsDbContext _db;

    public OperationsInspectionService(SolarOpsDbContext db)
    {
        _db = db;
    }

    public async Task<OperationsInspection> CreateInspectionAsync(Guid leadId)
    {
        var lead = await _db.Leads.FindAsync(leadId);

        if (lead == null)
            throw new Exception("Lead not found");

        if (lead.Status != LeadStatus.Scheduled)
            throw new Exception("Lead is not scheduled");

        var inspection = new OperationsInspection(leadId);

        _db.OperationsInspections.Add(inspection);

        await _db.SaveChangesAsync();

        return inspection;
    }
}
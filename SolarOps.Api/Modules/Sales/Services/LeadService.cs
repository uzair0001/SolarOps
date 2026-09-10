using SolarOps.Api.Infrastructure.Data;
using SolarOps.Api.Modules.Sales.DTO;
using SolarOps.Api.Modules.Sales.Models;


namespace SolarOps.Api.Modules.Sales.Services;

public class LeadService
{
    private readonly SolarOpsDbContext _db;

    private const decimal RedlinePpw = 2.50m;

    public LeadService(SolarOpsDbContext db)
    {
        _db = db;
    }

    //Create New Lead
    public async Task<Lead> CreateLeadAsync(CreateLeadRequest request)
    {
        var ppw = request.SystemPrice / (request.SystemSizeKw * 1000);

        var status = ppw >= RedlinePpw
            ? LeadStatus.Qualified
            : LeadStatus.Disqualified;

        var lead = new Lead(
            request.CustomerName,
            request.Phone,
            request.Email,
            request.Address,
            request.SystemSizeKw,
            request.SystemPrice);

        lead.SetQualification(ppw, status);

        _db.Leads.Add(lead);

        await _db.SaveChangesAsync();

        return lead;
    }

    // Schedule an inspection

    public async Task ScheduleLeadAsync(Guid leadId, DateTime scheduledAt)
    {
        var lead = await _db.Leads.FindAsync(leadId);

        if (lead == null)
            throw new Exception("Lead not found");

        lead.Schedule(scheduledAt);

        await _db.SaveChangesAsync();
    }




}
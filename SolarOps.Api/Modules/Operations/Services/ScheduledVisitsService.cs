using Microsoft.EntityFrameworkCore;
using SolarOps.Api.Infrastructure.Data;
using SolarOps.Api.Modules.Sales.Models;

namespace SolarOps.Api.Modules.Operations.Services;

public class ScheduledVisitService
{
    private readonly SolarOpsDbContext _db;

    public ScheduledVisitService(SolarOpsDbContext db)
    {
        _db = db;
    }

    public async Task<List<Lead>> GetScheduledVisitsAsync()
    {
        return await _db.Leads
            .Where(l => l.Status == LeadStatus.Scheduled)
            .ToListAsync();
    }
}
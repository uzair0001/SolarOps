

namespace SolarOps.Api.Modules.Sales.Models;

public enum LeadStatus
{
    Qualified,
    Disqualified,
    Scheduled
}

public class Lead
{
    public Guid Id { get; private set; }

    public string CustomerName { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string? Email { get; private set; }
    public string Address { get; private set; } = string.Empty;

    public decimal SystemSizeKw { get; private set; }
    public decimal SystemPrice { get; private set; }

    public decimal Ppw { get; private set; }
    public LeadStatus Status { get; private set; }

    public DateTime? ScheduledAt { get; private set; }



    public void Schedule(DateTime scheduledAt)
{
    ScheduledAt = scheduledAt;
    Status = LeadStatus.Scheduled;
}

    public void SetQualification(decimal ppw, LeadStatus status)
{
    Ppw = ppw;
    Status = status;
}

    public Lead(
        string customerName,
        string phone,
        string? email,
        string address,
        decimal systemSizeKw,
        decimal systemPrice)
    {
        Id = Guid.NewGuid();

        CustomerName = customerName;
        Phone = phone;
        Email = email;
        Address = address;

        SystemSizeKw = systemSizeKw;
        SystemPrice = systemPrice;
    }
}


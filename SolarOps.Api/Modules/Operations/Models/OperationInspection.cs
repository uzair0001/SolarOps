namespace SolarOps.Api.Modules.Operations.Models;

public class OperationsInspection
{
    public Guid Id { get; private set; }

    public Guid LeadId { get; private set; }

    public OperationsInspectionStatus Status { get; private set; }

    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    public string? Notes { get; private set; }

    public OperationsInspection(Guid leadId)
    {
        Id = Guid.NewGuid();
        LeadId = leadId;
        Status = OperationsInspectionStatus.WorkInProgress;
        StartedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        Status = OperationsInspectionStatus.Completed;
        CompletedAt = DateTime.UtcNow;
    }
}

public enum OperationsInspectionStatus
{
    WorkInProgress,
    Completed
}
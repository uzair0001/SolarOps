namespace SolarOps.Api.Modules.Sales.DTO;

public class CreateLeadRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Address { get; set; } = string.Empty;
    public decimal SystemSizeKw { get; set; }
    public decimal SystemPrice { get; set; }
}
using Microsoft.EntityFrameworkCore;
using SolarOps.Api.Modules.Sales.Models;
using SolarOps.Api.Modules.Operations.Models;

namespace SolarOps.Api.Infrastructure.Data;

public class SolarOpsDbContext : DbContext
{
    public SolarOpsDbContext(DbContextOptions<SolarOpsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Lead> Leads { get; set; }
    public DbSet<OperationsInspection> OperationsInspections { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lead>()
            .Property(l => l.Status)
            .HasConversion<string>();

        modelBuilder.Entity<OperationsInspection>()
    .HasOne<Lead>()
    .WithOne()
    .HasForeignKey<OperationsInspection>(i => i.LeadId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OperationsInspection>()
            .Property(i => i.Status)
            .HasConversion<string>();


    }
}
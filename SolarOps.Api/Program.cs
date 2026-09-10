using Microsoft.EntityFrameworkCore;
using SolarOps.Api.Infrastructure.Data;
using SolarOps.Api.Modules.Sales.Services;
using SolarOps.Api.Modules.Operations.Services;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SolarOpsDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("SolarOpsDb")));

builder.Services.AddScoped<LeadService>();      
builder.Services.AddScoped<ScheduledVisitService>(); 
builder.Services.AddScoped<OperationsInspectionService>(); 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

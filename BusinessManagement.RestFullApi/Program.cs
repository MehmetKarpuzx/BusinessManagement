using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Services;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BusinessManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessMng")));

builder.Services.AddScoped<IBranchServices,BranchServices>();




builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using BusinessManagement.Persistence.Contexts;
using BusinessManagement.Persistence.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BusinessManagement.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BusinessManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessMng")));

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

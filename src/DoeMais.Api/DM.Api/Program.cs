using DM.Core.Communication.Mediator;
using DM.Infrastructure.Data;
using DM.Infrastructure.Data.CommandsDb;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connectionStringMySql = builder.Configuration["MySql:Connection"];

builder.Services.AddDbContext<DoeMaisDbContextMySql>(x => x.UseMySql(connectionStringMySql, ServerVersion.AutoDetect(connectionStringMySql)));
builder.Services.InfrastructureData();
builder.Services.AddScoped<DoeMaisDbContextMySql>();
builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("DM.Application"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => {
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

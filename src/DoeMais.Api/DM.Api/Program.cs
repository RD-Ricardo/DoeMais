using DM.Application.BackgroundJobs;
using DM.Application.Services;
using DM.Core.Communication.Mediator;
using DM.Infrastructure.Data;
using DM.Infrastructure.Data.CommandsDb;
using DM.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connectionStringMySql = builder.Configuration["MySql:Connection"];

builder.Services.AddDbContext<DoeMaisDbContextMySql>((sp,x) => {
    var interceptor = sp.GetService<ConvertDomainEventOutBoxMessageInterceptor>();
    x.UseMySql(connectionStringMySql, ServerVersion.AutoDetect(connectionStringMySql))
    .AddInterceptors(interceptor);
 });
builder.Services.InfrastructureData();
builder.Services.AddScoped<DoeMaisDbContextMySql>();
builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

builder.Services.AddQuartz(configure =>
{
    var jobKey = new JobKey(nameof(ProcessamentoMessageOutbox));

    configure.AddJob<ProcessamentoMessageOutbox>(jobKey)
        .AddTrigger(trigger => 
            trigger.ForJob(jobKey)
                .WithSimpleSchedule(schedule => 
                    schedule.WithIntervalInSeconds(10)
                        .RepeatForever()));

    configure.UseMicrosoftDependencyInjectionJobFactory();
});

builder.Services.AddQuartzHostedService();

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

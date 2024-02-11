using EventManager.BL.Interfaces;
using EventManager.BL.Services;

using EventManager.DL.Interfaces;
using EventManager.DL.Repository;

using EventManager.HealthChecks;

using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMemberRepository, MemberRepository>();
builder.Services.AddSingleton<IEventRepository, EventRepository>();

builder.Services.AddSingleton<IMemberService, MemberService>();
builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IEventManagerService, EventManagerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

builder.Services
    .AddHealthChecks()
    .AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.MapHealthChecks("/healthz");

app.Run();

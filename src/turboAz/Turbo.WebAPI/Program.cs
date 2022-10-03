using Core.CrossCuttingConcers.Exceptions;
using Core.Security;
using Turbo.Application;
using Turbo.Infrastructure;
using Turbo.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(b =>
{
    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction()) app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();

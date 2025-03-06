using API.Extensions;
using Application.Extensions;
using FastEndpoints;
using Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var loggerFactory = LoggerFactory.Create(static loggingBuilder =>
{
  loggingBuilder.AddSerilog();
});

var logger = loggerFactory.CreateLogger("Program");

builder.Services.AddApiServices(logger); 
builder.Services.AddInfrastructureServices(builder.Configuration, logger);
builder.Services.AddApplicationServices(logger);

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwaggerUI(static c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
  });
}

app.UseHttpsRedirection();


app.UseFastEndpoints();

app.Run();
//https://localhost:7213/index.html
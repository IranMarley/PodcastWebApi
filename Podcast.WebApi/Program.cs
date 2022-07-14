using Podcast.Infra.Data.Context;
using Podcast.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Setting DBContext
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

// Enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
    builder => builder.AllowAnyOrigin());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
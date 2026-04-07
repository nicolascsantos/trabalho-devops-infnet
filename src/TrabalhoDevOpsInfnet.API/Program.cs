using TrabalhoDevOpsInfnet.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAndConfigureControllers();
builder.Services.AddAppConnections(builder.Configuration);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddUseCases();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDocumentation();

app.MapControllers();

app.Run();

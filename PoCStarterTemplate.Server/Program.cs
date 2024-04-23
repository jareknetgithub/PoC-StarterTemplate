using Contracts;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using LoggerService;
using NLog;
using PoCStarterTemplate;
using PoCStarterTemplate.Extensions;

var builder = WebApplication.CreateBuilder();
var secSettings = builder.Configuration.GetSection(nameof(Settings));
var settingsData = secSettings.Get<Settings>()!;

LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
builder.Services.Configure<Settings>(secSettings);
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureSqliteContext(builder.Configuration);
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth(settingsData.Auth.SigningKey);
builder.Services.AddAuthorization();

if (!builder.Environment.IsProduction())
{
    builder.Services.AddCors();
    builder.Services.SwaggerDocument();
}


var app = builder.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(c => c.Serializer.Options.PropertyNamingPolicy = null);

if (!builder.Environment.IsProduction())
{
    app.UseSwaggerGen();
}

app.Run();

public partial class Program { };


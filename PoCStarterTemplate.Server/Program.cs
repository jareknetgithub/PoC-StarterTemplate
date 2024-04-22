using FastEndpoints;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services
    .AddFastEndpoints()
    .SwaggerDocument();

var app = bld.Build();
app.UseFastEndpoints()
    .UseSwaggerGen();
app.Run();


public class HelloRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

#region "check server OK"
public class HelloResponse
{
    public string HelloMessage { get; set; }
    public string FullName { get; set; }
}


public class HelloEndpoint : Endpoint<HelloRequest, HelloResponse>
{
    public override void Configure()
    {
        Post("/api/hello");
        AllowAnonymous();
    }

    public override async Task HandleAsync(HelloRequest req, CancellationToken ct)
    {
        HelloResponse resResult = new HelloResponse()
        {
            FullName = $"{req.FirstName} {req.LastName}"
        };
        resResult.HelloMessage = $"Hello {resResult.FullName}";
        
        await SendAsync(resResult);
    }
}
#endregion
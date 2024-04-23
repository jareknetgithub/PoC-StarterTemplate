using FastEndpoints;
using NSwag.Annotations;

namespace PoCStarterTemplate
{
    #region "check server OK"
    public class HelloRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class HelloResponse
    {
        public string HelloMessage { get; set; }
        public string FullName { get; set; }
    }

    public class HelloEndpoint : Endpoint<HelloRequest, HelloResponse>
    {
        public override void Configure()
        {
            //just simple check endpoint metod types
            Verbs(Http.POST, Http.GET);
            Routes("/hello");

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
}

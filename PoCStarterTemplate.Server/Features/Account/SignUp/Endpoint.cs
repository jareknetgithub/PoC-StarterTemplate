using Contracts;

namespace Account.SignUp
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public IRepositoryManager RepositoryManager { get; set; } = default!;
        
        public override void Configure()
        {
            Verbs(Http.POST);
            AllowAnonymous(Http.POST);
            Routes("/account/signup");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Data.Repo = RepositoryManager;

            var acc = Map.ToEntity(r);
            
            await Data.SaveAccount(acc);

            await SendAsync(Map.FromEntity(acc));

        }
    }
}
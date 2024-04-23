using Contracts;

namespace Account.Get.Me
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public IRepositoryManager RepositoryManager { get; set; } = default!;
        
        public override void Configure()
        {
            Get("/account/me");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Data.Repo = RepositoryManager;
            var acc = await Data.GetAccountAsync(r.AccountID);
            if (acc == null)
            {
                await SendNotFoundAsync();
            }
            Response = Map.FromEntity(acc);
        }
    }
}
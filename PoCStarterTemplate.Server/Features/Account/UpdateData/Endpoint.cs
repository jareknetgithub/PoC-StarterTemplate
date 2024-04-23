using Contracts;

namespace Account.UpdateData
{
    internal sealed class Endpoint : Endpoint<Request, EmptyResponse, Mapper>
    {
        public IRepositoryManager RepositoryManager { get; set; } = default!;
        public override void Configure()
        {
            Put("/account/update/data");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Data.Repo = RepositoryManager;

            var acc2 = Data.GetAccountByID(r);
            if (acc2 == null)
            {
                await SendNotFoundAsync();
                return;
            }
            Map.UpdateEntity(r, acc2!);

            await Data.Repo.SaveASync();
            
        }
    }
}
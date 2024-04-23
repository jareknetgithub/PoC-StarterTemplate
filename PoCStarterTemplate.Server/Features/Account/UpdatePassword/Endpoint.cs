using Contracts;
using ToolsService;

namespace Account.UpdatePassword
{
    internal sealed class Endpoint : Endpoint<Request, EmptyResponse>
    {
        public IRepositoryManager RepositoryManager { get; set; } = default!;
        public override void Configure()
        {
            Put("/account/update/pwd");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            
            Account.Get.Me.Data.Repo = RepositoryManager;

            var acc = await Account.Get.Me.Data.GetAccountAsync(r.AccountID, true);
            if (acc == null)
            {
                await SendNotFoundAsync();
            }

            acc!.Password = r.Password.Pwd_MakeHash();

            await Account.Get.Me.Data.Repo.SaveASync();
        }
    }
}
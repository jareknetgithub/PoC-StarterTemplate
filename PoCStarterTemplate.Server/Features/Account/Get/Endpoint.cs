using Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PoCStarterTemplate.Auth;

namespace Account.Get
{
    internal sealed class Endpoint : Endpoint<EmptyRequest, Response, Mapper>
    {
        public IRepositoryManager RepositoryManager { get; set; } = default!;
               
        public override void Configure()
        {
            Get("/account/all");
            Permissions(Allow.Account_Read);
        }

        public override async Task HandleAsync(EmptyRequest r, CancellationToken c)
        {
            Data.Repo = RepositoryManager;

            var lstAccount = await Data.GetIdsRepoAsync(false);
            
         
            Response = Map.FromEntityList(lstAccount!);
        }
    }
}
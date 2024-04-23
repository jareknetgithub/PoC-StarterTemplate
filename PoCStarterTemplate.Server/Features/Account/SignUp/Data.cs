using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Account.SignUp
{
    internal static class Data
    {
        internal static IRepositoryManager Repo { get; set; } = default!;
        internal static Mapper MapperData { get; set; }

        internal static async Task SaveAccount(Entities.Models.Account acc)
        {
            Repo.Account.CreateAccount(acc);
            await Repo.SaveASync();
        }
    }
}

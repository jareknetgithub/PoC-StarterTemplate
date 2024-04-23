using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Account.Get.Me
{
    internal static class Data
    {
        internal static IRepositoryManager Repo { get; set; } = default!;

        internal static async Task<Entities.Models.Account?> GetAccountAsync(Guid accId, bool trackChanges = false)
        {
            return await Repo
                .Account.QueryByCondition(w => w.Id == accId, trackChanges)
                .SingleOrDefaultAsync();
        }

    }
}

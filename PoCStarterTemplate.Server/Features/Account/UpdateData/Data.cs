using Contracts;

namespace Account.UpdateData
{
    internal static class Data
    {
        internal static IRepositoryManager Repo { get; set; } = default!;

        internal static void UpdateAccount(Entities.Models.Account acc)
        {
            Repo.Account.UpdateAccount(acc);
        }

        internal static Entities.Models.Account? GetAccountByID(Request r)
        {
            return Repo.Account
                .QueryByCondition(q => q.Id == r.AccountID, true)
                .SingleOrDefault();
        }

        internal static void SetAccount(Entities.Models.Account acc)
        {
            
        }

    }
}

using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Account.Login
{
    internal static class Data
    {
        internal static IRepositoryManager Repo { get; set; } = default!;

        internal static Task<Entities.Models.Account> GetAccountAsync(string emailValue) 
        {
            var acc = Repo.Account.GetByEmailAsync(emailValue);
            return acc;
        }

        internal static async Task<Entities.Models.Account?> GetAccountBymailAsync(string emailValue)
        {
            var acc = await Repo.Account.QueryByCondition(c=>c.Email == emailValue).SingleOrDefaultAsync();

            return acc;
        }



    }
}

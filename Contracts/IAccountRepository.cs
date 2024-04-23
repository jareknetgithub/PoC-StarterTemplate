using Entities.Models;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts(bool trackChanges);
        Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackChanges);
        Task<Account?> GetByEmailAsync(string emailValue, bool trackChanges = false);
        IQueryable<Account> QueryByCondition(Expression<Func<Account, bool>> expression, bool trackChanges = false);
        IQueryable<Account> QueryAll(bool trackChanges = false);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
        void SetAccount(Account account);

    }
}

using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Repository
{
    public sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IQueryable<Account> QueryByCondition(Expression<Func<Account, bool>> expression, bool trackChanges = false)
        {
            return FindByCondition(expression, trackChanges);
        }

        public IQueryable<Account> QueryAll(bool trackChanges = false)
        {
            return FindAll(trackChanges);
        }

        public void CreateAccount(Account account) => Create(account);

        public IEnumerable<Account> GetAllAccounts(bool trackChanges) => 
            FindAll(trackChanges)
            .OrderBy(o=>o.Name)
            .ToList();

        public async Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(o=>o.Name)
                    .ToListAsync();

        public async Task<Account?> GetByEmailAsync(string emailValue, bool trackChanges = false) =>
            await FindByCondition(c => c.Email == emailValue, trackChanges)
                    .SingleOrDefaultAsync();

        public void UpdateAccount(Account account)
        {
            Update(account);
        }

        public void SetAccount(Account account) => SetEntry(account);

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }
    }
}

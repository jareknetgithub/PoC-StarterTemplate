using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(repositoryContext));
        }
        public IAccountRepository Account => _accountRepository.Value;

        public void Save() => _context.SaveChanges();

        public async Task SaveASync() => await _context.SaveChangesAsync();
    }
}

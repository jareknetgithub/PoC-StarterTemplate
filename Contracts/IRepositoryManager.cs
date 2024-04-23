namespace Contracts
{
    public interface IRepositoryManager
    {
        IAccountRepository Account {  get; }
        void Save();
        Task SaveASync();
    }
}

using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepoContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext) => RepoContext = repositoryContext;

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges? 
                                RepoContext.Set<T>().AsNoTracking():
                                RepoContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
                                RepoContext.Set<T>().Where(expression).AsNoTracking() :
                                RepoContext.Set<T>().Where(expression);

        public void Create(T entity) => RepoContext.Set<T>().Add(entity);
        public void Delete(T entity) => RepoContext.Set<T>().Remove(entity);
        public void Update(T entity) => RepoContext.Set<T>().Update(entity);
        public void SetEntry(T entity) => RepoContext.Entry<T>(entity);
    }
}

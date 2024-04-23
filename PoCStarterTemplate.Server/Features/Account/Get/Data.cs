using Contracts;
using Microsoft.EntityFrameworkCore;
namespace Account.Get
{
    public static class Data
    {
        public static IRepositoryManager Repo { get; set; } = default!;
        

        public static async Task<IEnumerable<Guid>> GetIds(bool trackChanges)
        {
            var resQuery = await Repo.Account.QueryAll().ToListAsync();

            return resQuery.Select(s=>s.Id).AsEnumerable();
        }

        public static async Task<IEnumerable<Entities.Models.Account>> GetIdsRepoAsync(bool trackChanges)
        {
            var resQuery = await Repo.Account.QueryAll().ToListAsync();

            return resQuery;
        }

        public static Response GetByCondition()
        {
            
            return new Response() { };
        }
    }
}

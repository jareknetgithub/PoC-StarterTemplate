using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System.Diagnostics;

namespace Repository
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions dbContextOptions):base (dbContextOptions) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }

        public DbSet<Account>? Accounts { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);*/
        //=> optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class; // Generic repository for entities
        Task<int> SaveChangesAsync(); // Commit all changes
        void BeginTransaction(); // Begin a transaction
        void CommitTransaction(); // Commit the transaction
        void RollbackTransaction(); // Rollback the transaction
    }
}


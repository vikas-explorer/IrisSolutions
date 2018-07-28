using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iris.Repos.Interfaces
{
    public interface IRepository<TEntity,TKey> where TEntity : class
    {
        IEnumerable<TEntity> GetEntiites();

        Task<TEntity> FindByIdAsync(TKey id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task DeleteAsync(TEntity entity);

        bool DoesExist(TKey id);
    }
}

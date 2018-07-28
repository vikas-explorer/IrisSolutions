using Iris.Infrastructure.Exceptions.Entities;
using Iris.Entities;
using Iris.Repos.DatabaseFramework;
using Iris.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iris.Repos
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogDbContext context;

        public CatalogRepository(CatalogDbContext catalogContext)
        {
            context = catalogContext;
        }

        public async Task CreateAsync(CatalogItem entity)
        {
            context.CatalogItems.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var catalog = await FindByIdAsync(id);
            if (catalog == null)
            {
                throw new EntityNotFoundException(string.Format("CatalogItem with {0} not found", id));
            }

            await DeleteAsync(catalog);
        }

        public async Task DeleteAsync(CatalogItem entity)
        {
            context.CatalogItems.Remove(entity);
            await context.SaveChangesAsync();
        }

        public bool DoesExist(int id)
        {
            return context.CatalogItems.Any(e => e.Id == id);
        }

        public async Task<CatalogItem> FindByIdAsync(int id)
        {
            return await context.CatalogItems.SingleOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<CatalogItem> GetEntiites()
        {
            return context.CatalogItems;
        }

        public async Task UpdateAsync(CatalogItem entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}

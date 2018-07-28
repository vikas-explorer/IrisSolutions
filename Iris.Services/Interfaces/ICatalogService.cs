using Iris.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Iris.Services.Interfaces
{
    public interface ICatalogService : IServiceBase
    {
        Task<int> CreateAsync(AddCatalogItemData catalogItemData);

        Task UpdateCatalogItemAsync(int catalogId, UpdateCatalogItemData catalogItemData);

        Task UpdateCatalogBrandAsync(int catalogBrandId, AddCatalogBrandData catalogBrandData);

        Task UpdateCatalogTypeAsync(int catalogTypeId, AddCatalogTypeData catalogTypeData);

        Task UpdateStockQuantity(int catalogId, int stockQuantity);

        IEnumerable<CatalogItemData> GetCatalogItems();

        Task<CatalogItemData> FindCatalogItemByAsync(int id);

        Task DeleteCatalogId(int catalogId);

        bool DoesCatalogItemExist(int catalogId);
    }
}

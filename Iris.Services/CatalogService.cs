using Iris.Entities;
using Iris.Models;
using Iris.Repos.Interfaces;
using Iris.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iris.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository catalogRepository;
        public CatalogService(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        public async Task<int> CreateAsync(AddCatalogItemData catalogItemData)
        {
            CatalogItem catalogItem = CatalogMapper.Convert(catalogItemData);
            await catalogRepository.CreateAsync(catalogItem);
            return catalogItem.Id;
        }

        public async Task DeleteCatalogId(int catalogId)
        {
            await catalogRepository.DeleteAsync(catalogId);
        }

        public bool DoesCatalogItemExist(int catalogId)
        {
            return catalogRepository.DoesExist(catalogId);
        }

        public async Task<CatalogItemData> FindCatalogItemByAsync(int id)
        {
            CatalogItem catalogItem = await catalogRepository.FindByIdAsync(id);
            CatalogItemData catalogItemData = CatalogMapper.Convert(catalogItem);
            return catalogItemData;
        }

        public IEnumerable<CatalogItemData> GetCatalogItems()
        {
            return catalogRepository.GetEntiites().Select(entity => CatalogMapper.Convert(entity));
        }

        public Task UpdateCatalogBrandAsync(int catalogBrandId, AddCatalogBrandData catalogBrandData)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCatalogItemAsync(int catalogId, UpdateCatalogItemData catalogItemData)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCatalogTypeAsync(int catalogTypeId, AddCatalogTypeData catalogTypeData)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStockQuantity(int catalogId, int stockQuantity)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogMapper
    {
        public static CatalogItemData Convert(CatalogItem catalogItem)
        {
            return new CatalogItemData()
            {
                PictureUri = catalogItem.PictureUri,
                Price = catalogItem.Price,
                Description = catalogItem.Description,
                Name = catalogItem.Name,
                AvailableStock = catalogItem.AvailableStock,
                CatalogTypeId = catalogItem.CatalogTypeId,
                CatalogBrandId = catalogItem.CatalogBrandId,
            };
        }

        public static CatalogItem Convert(AddCatalogItemData catalogItemData)
        {
            return new CatalogItem()
            {
                Price = catalogItemData.Price,
                Description = catalogItemData.Description,
                Name = catalogItemData.Name,
                AvailableStock = catalogItemData.AvailableStock,
                CatalogTypeId = catalogItemData.CatalogTypeId,
                CatalogBrandId = catalogItemData.CatalogBrandId,
            };
        }
    }
}

namespace Iris.Models
{
    public class UpdateCatalogItemData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public int CatalogTypeId { get; set; }

        public int CatalogBrandId { get; set; }

        // Quantity in stock
        public int AvailableStock { get; set; }

        public UpdateCatalogItemData()
        {

        }
    }
}

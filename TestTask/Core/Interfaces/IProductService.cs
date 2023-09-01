using Core.Entities.Product;

namespace Infrastructure.Data.Services
{
    public interface IProductService
    {
        Task<bool> CheckProductAvailability(Product product, ProductSize size, int requestedQuantity);
        Task<Product> CreateProductAsync(string productName, int categoryId, int sizeId, int availableQuantity, float price, string desc = null);
        Task<Product> GetProductAsync(int productId);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductCategory>> GetProductCategories();
        Task<IReadOnlyList<ProductSize>> GetProductSizes();
        Task<IReadOnlyList<ProductItem>> GetProductItemsAsync();
        Task<ProductItem> GetProductItemAsync(string productName, string categoryId);
        Task<ProductItem> GetProductItemAsync(int id);
        Task DeleteProductItemAsync(int productItemId);
    }
}
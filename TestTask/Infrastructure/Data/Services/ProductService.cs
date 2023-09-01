using Core.Entities.Product;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Data.Services;
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> CreateProductAsync(string productName,
                                                  int categoryId,
                                                  int sizeId,
                                                  int availableQuantity,
                                                  float price,
                                                  string desc = null)
    {
        var productSpec = new ProductWithCategorySpecification(productName, categoryId);
        var productInRepo = await _unitOfWork.Repository<Product>().GetEntityBySpecificationAsync(productSpec);
        int productId, res;
        Product productToReturn;

        if (productInRepo == null)
        {
            productToReturn = new Product(productName, categoryId, desc);
            _unitOfWork.Repository<Product>().Add(productToReturn);
            res = await _unitOfWork.CompleteAsync();
            if (res <= 0)
                return null;
            else
                productId = productToReturn.Id;
        }
        else
        {
            productId = productInRepo.Id;
            productToReturn = productInRepo;
        }

        var spec = new ProductItemSpecification(productToReturn.Name, productToReturn.CategoryId, sizeId);
        var productItemInRepo = await _unitOfWork.Repository<ProductItem>().GetEntityBySpecificationAsync(spec);

        if (productItemInRepo != null)
        {
            return productToReturn;
        }

        var productItem = new ProductItem(productId, categoryId, sizeId, price, availableQuantity);
        _unitOfWork.Repository<ProductItem>().Add(productItem);

        await _unitOfWork.CompleteAsync();

        return productToReturn;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var spec = new ProductWithCategorySpecification();

        return await _unitOfWork.Repository<Product>().GetAllWithSpecificationAsync(spec);
    }

    public async Task<Product> GetProductAsync(int productId)
    {
        var spec = new ProductWithCategorySpecification(productId);

        return await _unitOfWork.Repository<Product>().GetEntityBySpecificationAsync(spec);
    }

    public async Task<IReadOnlyList<ProductItem>> GetProductItemsAsync()
    {
        var spec = new ProductItemSpecification();

        return await _unitOfWork.Repository<ProductItem>().GetAllWithSpecificationAsync(spec);
    }

    public async Task<ProductItem> GetProductItemAsync(string productName, string category)
    {
        var spec = new ProductItemSpecification(productName, category);

        return await _unitOfWork.Repository<ProductItem>().GetEntityBySpecificationAsync(spec);
    }

    public async Task<ProductItem> GetProductItemAsync(int id)
    {
        var spec = new ProductItemSpecification(id);

        return await _unitOfWork.Repository<ProductItem>().GetEntityBySpecificationAsync(spec);
    }

    public async Task<bool> CheckProductAvailability(Product product, ProductSize size, int requestedQuantity)
    {
        var spec = new ProductItemSpecification(product.Name, product.CategoryId, size.Id);
        var productItem = await _unitOfWork.Repository<ProductItem>().GetEntityBySpecificationAsync(spec);

        if (productItem.AvailableQuantity >= requestedQuantity)
            return true;

        return false;
    }

    public async Task<IReadOnlyList<ProductCategory>> GetProductCategories()
    {
        return await _unitOfWork.Repository<ProductCategory>().GetAllAsync();
    }

    public async Task<IReadOnlyList<ProductSize>> GetProductSizes()
    {
        return await _unitOfWork.Repository<ProductSize>().GetAllAsync();
    }

    public async Task DeleteProductItemAsync(int productItemId)
    {
        var itemToDelete = await _unitOfWork.Repository<ProductItem>().GetByIdAsync(productItemId);
        if (itemToDelete != null)
        {
            _unitOfWork.Repository<ProductItem>().Delete(itemToDelete);
            await _unitOfWork.CompleteAsync();
        }
    }
}
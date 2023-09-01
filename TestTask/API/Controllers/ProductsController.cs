using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities.Product;
using Infrastructure.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _productService.GetProductAsync(id);
        return _mapper.Map<Product, ProductDto>(product);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ProductDto>>> GetProducts()
    {
        var products = await _productService.GetProductsAsync(); 
        return Ok(_mapper.Map<IReadOnlyCollection<Product>, IReadOnlyCollection<ProductDto>>(products));
    }

    [HttpGet("items/{productName}/{categoryId}")]
    public async Task<ActionResult<ProductItemDto>> GetProductItem(string productName, string category)
    {
        var productItem = await _productService.GetProductItemAsync(productName, category);
        return _mapper.Map<ProductItem, ProductItemDto>(productItem);
    }

    [HttpGet("items/{id}")]
    public async Task<ActionResult<ProductItemDto>> GetProductItem(int id)
    {
        var productItem = await _productService.GetProductItemAsync(id);
        return _mapper.Map<ProductItem, ProductItemDto>(productItem);
    }

    [HttpGet("items")]
    public async Task<ActionResult<IReadOnlyCollection<ProductItemDto>>> GetProductItems()
    {
        var productItems = await _productService.GetProductItemsAsync();
        return Ok(_mapper.Map<IReadOnlyCollection<ProductItem>, IReadOnlyCollection<ProductItemDto>>(productItems));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Post([FromBody] ProductItemDto productItemDto)
    {
        var product = await _productService.CreateProductAsync(
                productItemDto.ProductName, productItemDto.CategoryId, productItemDto.SizeId, productItemDto.AvailableQuantity,
                productItemDto.Price, productItemDto.Description);

        if (product == null)
            return BadRequest(new ApiResponse(400, "Problem creating the order"));

        return Ok(_mapper.Map<Product, ProductDto>(product));
    }

    [HttpDelete("items/{id}")]
    public async Task Delete(int id)
    {
       await _productService.DeleteProductItemAsync(id);
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyCollection<ProductCategory>>> GetProductCategories()
    {
        return Ok(await _productService.GetProductCategories());
    }

    [HttpGet("sizes")]
    public async Task<ActionResult<IReadOnlyList<ProductSize>>> GetProductSizes()
    {
        return Ok(await _productService.GetProductSizes());
    }
}

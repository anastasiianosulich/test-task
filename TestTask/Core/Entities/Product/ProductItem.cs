namespace Core.Entities.Product;

public class ProductItem : BaseEntity
{
    public ProductItem()
    {
    }

    public ProductItem(int productId, int categoryId, int sizeId, float price, int availableQuantity) 
    {
        ProductId = productId;
        CategoryId = categoryId;
        SizeId = sizeId;
        Price = price;
        AvailableQuantity = availableQuantity;
    }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; }
    public Product Product { get; set; }
    public ProductSize Size { get; set; }
    public int AvailableQuantity { get; set; }
    public float Price { get; set; }
}

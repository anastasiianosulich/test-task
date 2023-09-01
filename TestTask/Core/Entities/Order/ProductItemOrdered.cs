namespace Core.Entities.Order;

public class ProductItemOrdered
{
    public ProductItemOrdered()
    {
    }

    public ProductItemOrdered(int productItemId, string productName, string category, string size) 
    {
        ProductItemId = productItemId;
        ProductName = productName;
        Category = category;
        Size = size;
    }
    
    public int ProductItemId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public string Size { get; set; }
}

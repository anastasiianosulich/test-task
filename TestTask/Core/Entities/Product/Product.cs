using Core.Entities.Order;

namespace Core.Entities.Product;

public class Product : BaseEntity
{
    public Product()
    {
    }

    public Product(string name, int categoryId, string description) 
    {
        Name = name;
        CategoryId = categoryId;
        Description = description;
    }

    public string Name { get; set; }
    public ProductCategory Category { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public ICollection<ProductItem> ProductItems { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}

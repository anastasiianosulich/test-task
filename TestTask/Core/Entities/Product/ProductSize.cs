namespace Core.Entities.Product;

public class ProductSize : BaseEntity
{
    public ProductSize()
    {
    }

    public ProductSize(string name) 
    {
        Name = name;
    }
    public string Name { get; set; }

    public ICollection<ProductItem> ProductItems { get; set; }
}
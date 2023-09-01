namespace Core.Entities.Product;

public class ProductCategory : BaseEntity
{
    public ProductCategory()
    {
    }

    public ProductCategory(string name) 
    {
        Name = name;
    }
    public string Name { get; set; }
}
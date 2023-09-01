using Core.Entities.Product;

namespace Core.Entities.Order;

public class OrderItem : BaseEntity
{
    public OrderItem()
    {
    }

    public OrderItem(ProductItemOrdered itemOrdered, ProductSize size, int quantity, float price) 
    {
        ItemOrdered = itemOrdered;
        Quantity = quantity;
        Price = price;
        Size = size;
    }

    public ProductItemOrdered ItemOrdered { get; set; }
    public float Price { get; set; }
    public ProductSize Size { get; set; }
    public int Quantity { get; set; }
}

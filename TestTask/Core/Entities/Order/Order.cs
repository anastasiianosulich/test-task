using Core.Entities.Enums;

namespace Core.Entities.Order;

public class Order : BaseEntity
{
    public Order()
    {
    }

    public Order(int customerId, IReadOnlyList<OrderItem> orderItems, OrderStatus status, string comment) 
    {
        CustomerId = customerId;
        Comment = comment;
        Status = status;
        OrderItems = orderItems;
    }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public string Comment { get; set; }
    public IReadOnlyList<OrderItem> OrderItems { get; set; } 
    public float GetTotal() => OrderItems.Sum(oi => oi.Price * oi.Quantity);
}

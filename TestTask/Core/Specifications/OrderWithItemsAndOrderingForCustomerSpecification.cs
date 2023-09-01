using Core.Entities.Order;

namespace Core.Specifications
{
    public class OrderWithItemsAndOrderingForCustomerSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsAndOrderingForCustomerSpecification(int customerId) : base(o => o.CustomerId == customerId)
        {
            AddInclude(o => o.Customer);
            AddInclude(o => o.OrderItems);
            AddOrderByDescending(o => o.CreationDate);
        }
    }
}
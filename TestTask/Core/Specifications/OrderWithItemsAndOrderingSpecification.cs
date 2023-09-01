using Core.Entities.Order;

namespace Core.Specifications
{
    public class OrderWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsAndOrderingSpecification()
        {
            AddInclude(o => o.Customer);
            AddInclude(o => o.OrderItems);
            AddOrderByDescending(o => o.CreationDate);
        }

        public OrderWithItemsAndOrderingSpecification(int id) : base(o => o.Id == id)
        {
            AddInclude(o => o.Customer);
            AddInclude(o => o.OrderItems);
            AddOrderByDescending(o => o.CreationDate);
        }
    }
}
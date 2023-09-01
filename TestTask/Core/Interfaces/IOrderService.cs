using Core.Entities;
using Core.Entities.Enums;
using Core.Entities.Order;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int customerId, OrderStatus status, List<BasketItem> basketItemsItems, string comment = null);
        Task<IReadOnlyList<Order>> GetOrdersForCustomerAsync(int customerId);
        Task<IReadOnlyList<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        List<string> GetOrderStatuses();
    }
}
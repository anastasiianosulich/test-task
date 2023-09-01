using Core.Entities;
using Core.Entities.Enums;
using Core.Entities.Order;
using Core.Entities.Product;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(int customerId, OrderStatus status, List<BasketItem> basketItemsItems, string comment = null)
        {
          var orderItems = new List<OrderItem>();

            foreach (var item in basketItemsItems)
            {
                var sizeId = (await _unitOfWork.Repository<ProductSize>().GetAllAsync()).First(s => s.Name == item.Size).Id;

                var piSpec = new ProductItemSpecification(item.ProductId, sizeId);
                var productItem = await _unitOfWork.Repository<ProductItem>().GetEntityBySpecificationAsync(piSpec);

                if (productItem.AvailableQuantity < item.Quantity)
                    return null;

                productItem.AvailableQuantity -= item.Quantity;
                _unitOfWork.Repository<ProductItem>().Update(productItem);

                var itemOrdered = new ProductItemOrdered(productItem.Product.Id, productItem.Product.Name, productItem.Product.Category.Name, item.Size);

                var size = (await _unitOfWork.Repository<ProductSize>().GetAllAsync()).First(s => s.Name == item.Size);
                var orderItem = new OrderItem(itemOrdered, size, item.Quantity, productItem.Price);

                orderItems.Add(orderItem);
            }

            var order = new Order(customerId, orderItems, status, comment);

            _unitOfWork.Repository<Order>().Add(order);
            var res = await _unitOfWork.CompleteAsync();

            if(res <= 0)
              return null;

            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(orderId);

            return await _unitOfWork.Repository<Order>().GetEntityBySpecificationAsync(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersAsync()
        {
            var spec = new OrderWithItemsAndOrderingSpecification();

            return await _unitOfWork.Repository<Order>().GetAllWithSpecificationAsync(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForCustomerAsync(int customerId)
        {
            var spec = new OrderWithItemsAndOrderingForCustomerSpecification(customerId);

            return await _unitOfWork.Repository<Order>().GetAllWithSpecificationAsync(spec);
        }

        public List<string> GetOrderStatuses()
        { 
            return new List<string>(Enum.GetNames(typeof(OrderStatus)));
        }
    }
}
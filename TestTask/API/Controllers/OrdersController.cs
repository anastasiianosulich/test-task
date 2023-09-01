using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Entities.Enums;
using Core.Entities.Order;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var order = await _orderService.CreateOrderAsync(
                                                orderDto.CustomerId, 
                                                (OrderStatus)Enum.Parse(typeof(OrderStatus), orderDto.Status), 
                                                _mapper.Map<List<OrderItemDto>, List<BasketItem>>(orderDto.OrderItems), 
                                                orderDto.Comment);
            
            if(order == null)
                return BadRequest(new ApiResponse(400, "Problem creating the order"));
            
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if(order == null)
                return NotFound(new ApiResponse(404));

            return _mapper.Map<Order, OrderDto>(order);
        }

        [HttpGet("customerOrders/{customerId}")]
        public async Task<ActionResult<IReadOnlyCollection<OrderDto>>> GetOrders(int customerId)
        {
            var orders = await _orderService.GetOrdersForCustomerAsync(customerId); 
            
            return Ok(_mapper.Map<IReadOnlyCollection<Order>, IReadOnlyCollection<OrderDto>>(orders));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<OrderDto>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync(); 
            
            return Ok(_mapper.Map<IReadOnlyCollection<Order>, IReadOnlyCollection<OrderDto>>(orders));
        }

        [HttpGet("statuses")]
        public ActionResult<IReadOnlyCollection<string>> GetOrderStatuses()
        {
            return Ok(_orderService.GetOrderStatuses()); 
        }
    }
}
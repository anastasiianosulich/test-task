namespace API.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public float Total => OrderItems.Sum(oi => oi.Price * oi.Quantity);
    }
}
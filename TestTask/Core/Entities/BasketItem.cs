using Core.Entities.Product;

namespace Core.Entities
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
namespace API.Dtos
{
    public class ProductItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int AvailableQuantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

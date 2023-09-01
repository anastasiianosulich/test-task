using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Required]
        public string Size { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
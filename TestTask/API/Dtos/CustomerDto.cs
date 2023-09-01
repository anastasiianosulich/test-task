using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
    }
}
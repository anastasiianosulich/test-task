using Core.Entities;
using Core.Entities.Order;

public class Customer : BaseEntity
{
    public DateTime JoiningDate { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public string Address { get; set; }
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
}
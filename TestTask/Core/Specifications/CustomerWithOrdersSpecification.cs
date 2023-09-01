namespace Core.Specifications
{
    public class CustomerWithOrdersSpecification : BaseSpecification<Customer>
    {
        public CustomerWithOrdersSpecification()
        {
            AddInclude(c => c.Orders);
        }

        public CustomerWithOrdersSpecification(int id) : base(c => c.Id == id)
        {
            AddInclude(c => c.Orders);
        }
    }
}
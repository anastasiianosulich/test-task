using Core.Entities.Product;

namespace Core.Specifications
{
    public class ProductWithCategorySpecification: BaseSpecification<Product>
    {
        public ProductWithCategorySpecification()
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(string name, int categoryId) : base(p => p.Name == name && p.CategoryId == categoryId)
        {
            AddInclude(p => p.Category);
        }
    }
}
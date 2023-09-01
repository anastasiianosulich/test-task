using Core.Entities.Product;

namespace Core.Specifications
{
    public class ProductItemSpecification : BaseSpecification<ProductItem> 
    {
        public ProductItemSpecification(string productName, string category) 
                : base(pi => pi.Product.Name == productName && pi.Category.Name == category)
        {
            AddInclude(pi => pi.Size);
            AddInclude(pi => pi.Category);
            AddInclude(pi => pi.Product);
            AddOrderBy(pi => pi.Product.Name);
        }

        public ProductItemSpecification(string productName, int categoryId, int sizeId)
                : base(pi => pi.Product.Name == productName && pi.SizeId == sizeId && pi.CategoryId == categoryId)
        {
            AddInclude(pi => pi.Size);
            AddInclude(pi => pi.Category);
            AddInclude(pi => pi.Product);
            AddOrderBy(pi => pi.Product.Name);
        }

        public ProductItemSpecification(int productId, int sizeId)
                : base(pi => pi.Id == productId && pi.Size.Id == sizeId)
        {
            AddInclude(pi => pi.Size);
            AddInclude(pi => pi.Category);
            AddInclude(pi => pi.Product);
            AddOrderBy(pi => pi.Product.Name);
        }

        public ProductItemSpecification()
        {
            AddInclude(pi => pi.Size);
            AddInclude(pi => pi.Category);
            AddInclude(pi => pi.Product);
            AddOrderBy(pi => pi.Product.Name);
        }

        public ProductItemSpecification(int id)
                : base(pi => pi.Id == id)
        {
            AddInclude(pi => pi.Size);
            AddInclude(pi => pi.Category);
            AddInclude(pi => pi.Product);
            AddOrderBy(pi => pi.Product.Name);
        }
    }
}
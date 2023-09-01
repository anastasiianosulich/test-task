using Bogus;
using Core.Entities.Product;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(StoreContext dbContext)
        {
            if (dbContext.Customers.Any())
            {
                return;

                var c = dbContext.Customers.ToList();
                dbContext.Customers.RemoveRange(c);

                var p = dbContext.ProductCategories.ToList();
                dbContext.ProductCategories.RemoveRange(p);

                var r = dbContext.ProductSizes.ToList();
                dbContext.ProductSizes.RemoveRange(r);

                var b = dbContext.Products.ToList();
                dbContext.Products.RemoveRange(b);

                dbContext.SaveChanges();
            }
                
            var faker = new Faker();

            // Seed Customers
            var customers = Enumerable.Range(1, 5)
                .Select(_ => new Customer
                {
                    Name = faker.Name.FullName(),
                    Address = faker.Address.FullAddress(),
                    JoiningDate = faker.Date.Past(),
                })
                .ToList();

            dbContext.Set<Customer>().AddRange(customers);

            var productCategories = new List<string>{"Food", "Clothes", "Sport", "Health", "Electronics", "Household"};
            dbContext.Set<ProductCategory>().AddRange(productCategories.Select(pc => new ProductCategory{ Name = pc }));

            var productSizes = new List<string> { "Small", "Medium", "Large", "Extra large" };
            dbContext.Set<ProductSize>().AddRange(productSizes.Select(pc => new ProductSize { Name = pc }));

            dbContext.SaveChanges();

        }
    }
}
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.HasOne(ps => ps.Product)
                .WithMany(p => p.ProductItems)
                .HasForeignKey(ps => ps.ProductId);

            builder.HasOne(ps => ps.Size)
                .WithMany(s => s.ProductItems)
                .HasForeignKey(ps => ps.SizeId);

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
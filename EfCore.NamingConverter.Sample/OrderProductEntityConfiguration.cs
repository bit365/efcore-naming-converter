using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.NamingConverter.Sample
{
    public class OrderProductEntityConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => new { x.Id, x.CategoryId });
            builder.Property(x => x.ProductName).HasMaxLength(100);
            builder.HasIndex(x => x.ProductName).IsUnique();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsRegister.Business.Models;

namespace ProductsRegister.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            builder.ToTable("Products");
        }
    }
}

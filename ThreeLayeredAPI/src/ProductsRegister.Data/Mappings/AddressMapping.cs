using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsRegister.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsRegister.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(x => x.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)");
            builder.Property(x => x.Complement)
                .HasColumnType("varchar(250)");
            builder.Property(x => x.Nieghbourhood)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Addresses");
        }
    }
}

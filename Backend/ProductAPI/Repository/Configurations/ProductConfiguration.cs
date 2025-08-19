using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);

            builder.Property(p => p.Price).HasColumnType("decimal(9,2)");
            builder.Property(p => p.Stock).HasDefaultValue(0);

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);

        }
    }
}

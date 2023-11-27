using DataModels.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Mappings.OrderMapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired(false);
            builder.Property(x => x.ProductName).HasColumnName("ProductName").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Status).HasColumnName("Status").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false);
        }
    }
}
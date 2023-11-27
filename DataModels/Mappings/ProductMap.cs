using DataModels.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Image).HasColumnName("Image").HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.Description).HasColumnName("Description").IsRequired(true);
            builder.Property(x => x.MetaInfo).HasColumnName("MetaInfo").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.UrlReferer).HasColumnName("UrlReferer").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false);
            builder.HasOne(x => x.ProductType).WithMany(x => x.Products).HasForeignKey(x => x.ProductTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

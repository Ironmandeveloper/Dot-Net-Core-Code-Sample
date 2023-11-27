using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Mappings
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).HasColumnName("Name").IsRequired(true);
            builder.Property(x => x.MetaInfo).HasMaxLength(50).HasColumnName("MetaInfo").IsRequired(false);
            builder.Property(x => x.UrlReferer).HasMaxLength(50).HasColumnName("UrlReferer").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false);
        }
    }
}

using DataModels.Models.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Mappings.ReviewMapping
{
    public class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Reviewid);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Rating).HasColumnName("Rating").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(254).IsRequired(false);
            builder.Property(x => x.Reviews).HasColumnName("Reviews").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false);
        }
    }
}

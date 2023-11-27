using DataModels.Models.Faq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Mappings.FaqMapping
{
    public class FaqMap : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired(false);
            builder.Property(x => x.Question).HasColumnName("Question").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Answer).HasColumnName("Answer").IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false);
        }
    }
}

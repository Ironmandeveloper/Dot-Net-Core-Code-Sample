using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Mappings.AnonyousUsersMapping
{
    public class AnonymousUsersMap : IEntityTypeConfiguration<AnonymousUsers>
    {
        public void Configure(EntityTypeBuilder<AnonymousUsers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false);
        }
    }
}

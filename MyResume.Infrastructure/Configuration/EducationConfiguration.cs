using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyResume.Domain.Core.BaseEntityConfiguration;
using MyResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Configuration
{
    public class EducationConfiguration : BaseEntityConfiguration<Education>
    {
        public override void Configure(EntityTypeBuilder<Education> builder)
        {


            builder.Property(a => a.School).IsRequired().HasMaxLength(128);
            builder.Property(a => a.Departman).IsRequired().HasMaxLength(128);
            builder.Property(a => a.StartDateTime).IsRequired(false);
            builder.Property(a => a.EndDateTime).IsRequired(false);
            builder.Property(a => a.Description).IsRequired(false).HasMaxLength(1300);
            base.Configure(builder);
        }
    }
}

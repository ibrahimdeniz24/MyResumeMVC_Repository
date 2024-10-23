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
    public class SummaryConfiguration :BaseEntityConfiguration<Summary>
    {
        public override void Configure(EntityTypeBuilder<Summary> builder)
        {


            builder.Property(a => a.Name).IsRequired().HasMaxLength(128);
            builder.Property(a => a.Description).IsRequired(false).HasMaxLength(1000);
            base.Configure(builder);
        }

    }
}

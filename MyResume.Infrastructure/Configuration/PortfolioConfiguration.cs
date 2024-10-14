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
    public class PortfolioConfiguration :BaseEntityConfiguration<Portfolio>
    {
        public override void Configure(EntityTypeBuilder<Portfolio> builder)
        {


            builder.Property(a => a.ProjectDate).IsRequired();
            builder.Property(a => a.ProjectName).IsRequired();
            builder.Property(a => a.Url).IsRequired(false);
            builder.Property(a => a.Category).IsRequired(false);
            builder.Property(a => a.Description).IsRequired();
            base.Configure(builder);
        }
    }
}

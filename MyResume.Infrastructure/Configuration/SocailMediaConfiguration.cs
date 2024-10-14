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
    public class SocailMediaConfiguration : BaseEntityConfiguration<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(a => a.Url).IsRequired();
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Icon).IsRequired(false);
            base.Configure(builder);
        }
    }
}

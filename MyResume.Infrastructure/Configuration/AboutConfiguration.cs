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
    public  class AboutConfiguration:BaseEntityConfiguration<About>
    {
        public override void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.Head).IsRequired().HasMaxLength(128);
            builder.Property(a => a.HeadDesciprtion).IsRequired(false).HasMaxLength(128);
            builder.Property(a => a.ProfilePicture).IsRequired(false);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(128);
            builder.Property(a => a.TitleDescription).IsRequired(false).HasMaxLength(128);
            builder.Property(a => a.SubDescription).IsRequired(false).HasMaxLength(128);
            builder.Property(a => a.Degree).IsRequired(false).HasMaxLength(128);
            builder.Property(a => a.BirthDate).IsRequired();
            builder.Property(a => a.Age).IsRequired(false);
            builder.Property(a => a.WebSite).IsRequired(false);
            builder.Property(a => a.Phone).IsRequired(false);
            builder.Property(a => a.FreeLance).IsRequired(false);
            builder.Property(a => a.City).IsRequired().HasMaxLength(128);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(128);

            base.Configure(builder);
        }
    }
}

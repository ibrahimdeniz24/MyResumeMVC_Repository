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
    public class FeatureConfiguration :BaseEntityConfiguration<Feature>
    {
        public override void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(128);
            builder.Property(a =>a.Title).IsRequired().HasMaxLength(128);
            builder.Property(a =>a.Title1).IsRequired(false).HasMaxLength(128);
            builder.Property(a =>a.Title2).IsRequired(false).HasMaxLength(128);
            builder.Property(a =>a.Title3).IsRequired(false).HasMaxLength(128);


            base.Configure(builder);
        }
    }
}

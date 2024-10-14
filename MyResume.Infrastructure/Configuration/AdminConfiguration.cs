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
    public class AdminConfiguration :BaseEntityConfiguration<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
            builder.Property(a => a.IdentityId).IsRequired();

            base.Configure(builder);
        }
    }
}

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
    public class ContactConfiguration :BaseEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Description).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Phone).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Adress).IsRequired().HasMaxLength(150);
            base.Configure(builder);
        }
    }
}

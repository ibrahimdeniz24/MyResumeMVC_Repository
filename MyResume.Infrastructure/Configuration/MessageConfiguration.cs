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
    public class MessageConfiguration :BaseEntityConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.Property(a=>a.Subject).IsRequired(false);
            builder.Property(a=>a.NameSurname).IsRequired(false);
            builder.Property(a=>a.MessageDetail).IsRequired(false);
            builder.Property(a=>a.SendDate).IsRequired(false);
            builder.Property(a=>a.IsRead).IsRequired(false);
            base.Configure(builder);
        }
    }
}

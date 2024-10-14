using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using MyResume.Domain.Core.BaseEntityConfiguration;
using MyResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Configuration
{
    public class ResumeConfiguration : BaseEntityConfiguration<Resume>
    {
        public override void Configure(EntityTypeBuilder<Resume> builder)
        {

            builder.Property(a => a.Head).IsRequired();
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.Desciption).IsRequired();


            base.Configure(builder);
        }
    }
}

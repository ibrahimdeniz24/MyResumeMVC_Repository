using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Entities;
using MyResume.Infrastructure.AppContext;
using MyResume.Infrastructure.DataAccsess.EntityFramework;
using MyResume.Infrastructure.Repositories.FeatureRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.AboutRepositories
{
    public class AboutRepositories : EFBaseRepository<About>, IAboutRepositories
    {
        public AboutRepositories(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

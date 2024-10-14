using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Entities;
using MyResume.Infrastructure.AppContext;
using MyResume.Infrastructure.DataAccsess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.FeatureRepositories
{
    public class FeatureRepository : EFBaseRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

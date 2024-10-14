using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.FeatureRepositories
{
    public interface IFeatureRepository :IAsyncRepository,IAsyncInsertableRepository<Feature>,IAsyncFindableRepository<Feature>,IAsyncDeleteableRepository<Feature>,IAsyncOrderableRepository<Feature>,IAsyncQueraybleRepository<Feature>,IAsyncUpdatableRepository<Feature>
    {
    }
}

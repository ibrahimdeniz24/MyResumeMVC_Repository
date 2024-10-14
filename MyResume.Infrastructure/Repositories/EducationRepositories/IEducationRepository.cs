using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.EducationRepositories
{
    public interface IEducationRepository : IAsyncRepository, IAsyncInsertableRepository<Education>, IAsyncFindableRepository<Education>, IAsyncDeleteableRepository<Education>, IAsyncOrderableRepository<Education>, IAsyncQueraybleRepository<Education>, IAsyncUpdatableRepository<Education>
    {
    }
}

using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.ResumeRepositories
{
    public interface IResumeRepository : IAsyncRepository, IAsyncInsertableRepository<Resume>, IAsyncFindableRepository<Resume>, IAsyncDeleteableRepository<Resume>, IAsyncOrderableRepository<Resume>, IAsyncQueraybleRepository<Resume>, IAsyncUpdatableRepository<Resume>
    {
    }
}

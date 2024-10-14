using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.SummaryRepositories
{
    public interface ISummaryRepository : IAsyncRepository, IAsyncInsertableRepository<Summary>, IAsyncFindableRepository<Summary>, IAsyncDeleteableRepository<Summary>, IAsyncOrderableRepository<Summary>, IAsyncQueraybleRepository<Summary>, IAsyncUpdatableRepository<Summary>
    {
    }
}

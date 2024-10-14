using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.AboutRepositories
{
    public interface IAboutRepositories : IAsyncRepository, IAsyncInsertableRepository<About>, IAsyncFindableRepository<About>, IAsyncDeleteableRepository<About>, IAsyncOrderableRepository<About>, IAsyncQueraybleRepository<About>, IAsyncUpdatableRepository<About>
    {
    }
}

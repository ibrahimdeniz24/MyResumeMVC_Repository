using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.PortfolioRepositories
{
    public interface IPortfolioRepository : IAsyncRepository, IAsyncInsertableRepository<Portfolio>, IAsyncFindableRepository<Portfolio>, IAsyncDeleteableRepository<Portfolio>, IAsyncOrderableRepository<Portfolio>, IAsyncQueraybleRepository<Portfolio>, IAsyncUpdatableRepository<Portfolio>
    {
    }
}

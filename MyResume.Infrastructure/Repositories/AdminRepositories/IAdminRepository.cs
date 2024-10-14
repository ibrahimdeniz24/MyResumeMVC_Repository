using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.AdminRepositories
{
    public interface IAdminRepository : IAsyncRepository, IAsyncInsertableRepository<Admin>, IAsyncFindableRepository<Admin>, IAsyncDeleteableRepository<Admin>, IAsyncOrderableRepository<Admin>, IAsyncQueraybleRepository<Admin>, IAsyncUpdatableRepository<Admin>
    {
    }
}

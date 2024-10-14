using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.SkillRepositories
{
    public interface ISkillRepository : IAsyncRepository, IAsyncInsertableRepository<Skill>, IAsyncFindableRepository<Skill>, IAsyncDeleteableRepository<Skill>, IAsyncOrderableRepository<Skill>, IAsyncQueraybleRepository<Skill>, IAsyncUpdatableRepository<Skill>
    {
    }
}

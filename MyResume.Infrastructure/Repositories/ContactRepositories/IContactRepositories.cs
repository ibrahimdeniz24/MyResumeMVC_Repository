using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.ContactRepositories
{
    public interface IContactRepositories : IAsyncRepository, IAsyncInsertableRepository<Contact>, IAsyncFindableRepository<Contact>, IAsyncDeleteableRepository<Contact>, IAsyncOrderableRepository<Contact>, IAsyncQueraybleRepository<Contact>, IAsyncUpdatableRepository<Contact>
    {
    }
}

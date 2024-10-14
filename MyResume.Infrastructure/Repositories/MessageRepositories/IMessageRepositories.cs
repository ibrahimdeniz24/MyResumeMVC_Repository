using MyResume.Domain.Entities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.MessageRepositories
{
    public interface IMessageRepositories : IAsyncRepository, IAsyncFindableRepository<Message>, IAsyncDeleteableRepository<Message>, IAsyncOrderableRepository<Message>, IAsyncQueraybleRepository<Message>,IAsyncUpdatableRepository<Message>,IAsyncInsertableRepository<Message>
    {
    }

}

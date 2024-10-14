using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.DataAccsess.Interfaces
{
    public interface IAsyncTransactionRepository
    {
        Task<IExecutionStrategy> CreateExecutionStrategy();
        Task<IDbContextTransaction> BeginTransactionAsync (CancellationToken cancellationToken=default);
    }
}

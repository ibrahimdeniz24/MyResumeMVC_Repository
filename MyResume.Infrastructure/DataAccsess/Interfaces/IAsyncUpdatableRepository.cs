﻿
using MyResume.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.DataAccsess.Interfaces
{
    public interface IAsyncUpdatableRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}

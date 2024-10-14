
using MyResume.Domain.Core.BaseEntities;

namespace MyResume.Infrastructure.DataAccsess.Interfaces
{
    public interface IAsyncDeleteableRepository<TEntitiy> where TEntitiy : BaseEntity
    {
        Task DeleteAsync(TEntitiy entitiy);
        Task DeleteRangeAsync(IEnumerable<TEntitiy> entities);
    }
}

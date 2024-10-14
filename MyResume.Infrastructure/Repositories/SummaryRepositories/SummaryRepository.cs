
using MyResume.Domain.Entities;
using MyResume.Infrastructure.AppContext;
using MyResume.Infrastructure.DataAccsess.EntityFramework;

namespace MyResume.Infrastructure.Repositories.SummaryRepositories
{
    public class SummaryRepository : EFBaseRepository<Summary>, ISummaryRepository
    {
        public SummaryRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

       
    }
}

using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Entities;
using MyResume.Infrastructure.AppContext;
using MyResume.Infrastructure.DataAccsess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.PortfolioRepositories
{
    public class PortfolioRepository : EFBaseRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

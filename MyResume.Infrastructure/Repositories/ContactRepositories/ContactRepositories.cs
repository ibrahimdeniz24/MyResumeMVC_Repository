using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Entities;
using MyResume.Infrastructure.AppContext;
using MyResume.Infrastructure.DataAccsess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Infrastructure.Repositories.ContactRepositories
{
    public class ContactRepositories : EFBaseRepository<Contact>, IContactRepositories
    {
        public ContactRepositories(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyResume.Domain.Core.BaseEntities;
using MyResume.Infrastructure.DataAccsess.Interfaces;
using System.Linq.Expressions;

namespace MyResume.Infrastructure.DataAccsess.EntityFramework
{
    public class EFBaseRepository<TEntity> : IRepository, IAsyncRepository, IAsyncInsertableRepository<TEntity>, IAsyncUpdatableRepository<TEntity>, IAsyncDeleteableRepository<TEntity>, IAsyncFindableRepository<TEntity>,IAsyncQueraybleRepository<TEntity>,IAsyncOrderableRepository<TEntity>,IAsyncTransactionRepository where TEntity : BaseEntity
    {

        //burada neden db contexi verdik kalıtım aldıgı her appdbcontexte kullanılabilsin diye. hepsi için ayr atrı kullanmayalım diye.
        protected readonly DbContext _dbContext; //kalıtım verdiği yerde kullanabilir.
        //table sabit tüm tablee kullaılabilsin diye.
        protected readonly DbSet<TEntity> _table; //kalıtım verdiği yerde kullanabilir.


        public EFBaseRepository(DbContext dbContext)
        {
            //burada neden db contexi verdik kalıtım aldıgı her appdbcontexte kullanılabilsin diye.
            _dbContext = dbContext;
            _table = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var enrty = await _table.AddAsync(entity);
            return enrty.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression is null ? await GetAllActives().AnyAsync() : await GetAllActives().AnyAsync(expression);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
           return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }


        public Task<IExecutionStrategy> CreateExecutionStrategy()
        {
            //async olmayan metodu asycn çevirme yöntemi
            return Task.FromResult(_dbContext.Database.CreateExecutionStrategy());
        }

        public async Task DeleteAsync(TEntity entitiy)
        {
            await Task.FromResult(_table.Remove(entitiy).Entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true)
        {
            return await GetAllActives(tracking).ToListAsync();
        }

        public async  Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return await GetAllActives(tracking).Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<Tkey>(Expression<Func<TEntity, Tkey>> orderby, bool orderByDesc, bool tracking = true)
        {
            return orderByDesc ? await GetAllActives(tracking).OrderByDescending(orderby).ToListAsync() : await GetAllActives(tracking).OrderBy(orderby).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<Tkey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, Tkey>> orderby, bool orderByDesc, bool tracking = true)
        {
            var values = GetAllActives(tracking).Where(expression);//Takip ve koşul durumu

            return orderByDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync(); //sıralama kuşuru ders mi düzmü ona göre return et.
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return await GetAllActives(tracking).FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, bool tracking = true)
        {

            return await GetAllActives(tracking).FirstOrDefaultAsync(x => x.Id == id);

        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(_table.Update(entity).Entity);
        }

        //bu ımplementeden gelmedi.
        protected IQueryable<TEntity> GetAllActives(bool tracking = true)
        {
            //statüsü deleted olanları getirme.
            var values = _table;

            return tracking ? values : values.AsNoTracking(); //Gelen veri trackinge tdahil olmadan gelir.


        }
    }
}

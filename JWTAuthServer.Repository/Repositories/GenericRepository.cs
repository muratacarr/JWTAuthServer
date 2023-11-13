using JWTAuthServer.Core.Repositories;
using JWTAuthServer.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWTAuthServer.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity=await _dbSet.FindAsync(id);
            if (entity!=null)
            {
                _appDbContext.Entry(entity).State = EntityState.Detached; //Update kısmında yapacağımız zaman orada da 2 tane state çakışmaması olmaması için burada Detached yaptık.
            }
            return entity;
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Entry(entity).State= EntityState.Modified;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

using CvAnalyzer.Domian.Contracts;
using CvAnalyzer.Domian.Entities;
using CvAnalyzer.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly AnalyzerDbcontext _dbContext;

        public GenericRepository(AnalyzerDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(TEntity entity) => _dbContext.Add(entity);

        public void Delete(TEntity entity) => _dbContext.Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            if (Condition is null)
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            else
                return await _dbContext.Set<TEntity>().AsNoTracking().Where(Condition).ToListAsync();
        }


        public async Task<TEntity?> GetByIdAsync(TKey Id) => await _dbContext.Set<TEntity>().FindAsync(Id);

        public void Update(TEntity entity) => _dbContext.Update(entity);
    }
}

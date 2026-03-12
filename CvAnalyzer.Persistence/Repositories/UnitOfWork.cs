using CvAnalyzer.Domian.Contracts;
using CvAnalyzer.Domian.Entities;
using CvAnalyzer.Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnalyzerDbcontext _dbContext;
        private readonly Dictionary<Type, object> _repositories = [];

        public UnitOfWork(AnalyzerDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var EntityType = typeof(TEntity);
            if (_repositories.TryGetValue(EntityType, out var repository))
                return (IGenericRepository<TEntity, TKey>)repository;
            var NewRepo = new GenericRepository<TEntity, TKey>(_dbContext);
            _repositories[EntityType] = NewRepo;
            return NewRepo;
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}

using CvAnalyzer.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CvAnalyzer.Domian.Contracts
{
    public interface IGenericRepository<TEntity , TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey Id);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> Condition = null);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);


        
    }
}

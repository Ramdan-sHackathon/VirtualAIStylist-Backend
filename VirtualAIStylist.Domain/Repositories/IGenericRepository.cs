using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Entities;

namespace VirtualAIStylist.Domain.Repositories
{
	public interface IGenericRepository<TKey,TEntity> where TEntity:BaseEntity<TKey>
	{
		Task AddAsync(TEntity entity);
		Task AddRangeAsync(IEnumerable<TEntity> entities);
		Task<IReadOnlyList<TEntity>> GetAllAsync();

		Task<IReadOnlyList<TEntity>> GetWithPrdicate(Expression<Func<TEntity,bool>> pridecate);

		void RemoveRange(IEnumerable<TEntity> entities);
		void Remove(TEntity entity);
	}
}

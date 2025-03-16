using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Entities;
using VirtualAIStylist.Domain.Repositories;
using VirtualAIStylist.Persistence.Data;

namespace VirtualAIStylist.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly VirtualAIStylistDbContext _context;
		private readonly Dictionary<string, object> _repositories = new();

		public UnitOfWork(VirtualAIStylistDbContext context)
		{
			_context = context;
		}

		public IGenericRepository<TKey,TEntity> Repository<TKey,TEntity>() where TEntity : BaseEntity<TKey>
		{
			var typeName = typeof(TEntity).Name;

			if (!_repositories.ContainsKey(typeName))
			{
				var repositoryInstance = new GenericRepository<TKey,TEntity>(_context);
				_repositories[typeName] = repositoryInstance;
			}

			return (IGenericRepository<TKey,TEntity>)_repositories[typeName];
		}

		public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}

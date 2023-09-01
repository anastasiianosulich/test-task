using System.Collections;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repos;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if(_repos == null)
                _repos = new Hashtable();

            var typeName = typeof(T).Name;

            if(!_repos.ContainsKey(typeName))
            {
                var repoType = typeof(GenericRepository<>);
                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), _context);

                _repos.Add(typeName, repoInstance);
            }

            return (IGenericRepository<T>) _repos[typeName];
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
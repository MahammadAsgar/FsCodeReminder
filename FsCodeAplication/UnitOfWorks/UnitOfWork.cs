using FsCodeAplication.Content;
using FsCodeAplication.Repositories.Abstractions;
using FsCodeAplication.Repositories.Implementations;
using FsCodeDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FsCodeAplication.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FsCodeDbContent _fsCodeDbContent;
        private bool _isDisposed = false;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(FsCodeDbContent fsCodeDbContent)
        {
            _fsCodeDbContent = fsCodeDbContent;
            _repositories = new Dictionary<Type, object>();
        }
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)) == true)
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;

            var repo = new GenericRepository<TEntity>(_fsCodeDbContent);

            _repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public void Commit()
        {
            var entities = _fsCodeDbContent.ChangeTracker.Entries<BaseEntity>();

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.CreatedDate = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Entity.UpdatedDate = DateTime.Now;
                }
            }
            _fsCodeDbContent.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _fsCodeDbContent.Dispose();
                _isDisposed = true;
            }
        }

        private TRepository GetRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.GetExecutingAssembly().GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new Exception("Repository type is not found");

            var repository = (TRepository)Activator.CreateInstance(type, _fsCodeDbContent);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }
    }
}

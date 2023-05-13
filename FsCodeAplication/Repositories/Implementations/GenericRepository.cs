using FsCodeAplication.Content;
using FsCodeAplication.Repositories.Abstractions;
using FsCodeDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FsCodeAplication.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly FsCodeDbContent _dbContext;
        public GenericRepository(FsCodeDbContent dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}

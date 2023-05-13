using FsCodeDomain.Entities;

namespace FsCodeAplication.Repositories.Abstractions
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Update(TEntity entity);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}

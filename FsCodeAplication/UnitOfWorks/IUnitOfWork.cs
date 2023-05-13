using FsCodeAplication.Repositories.Abstractions;
using FsCodeDomain.Entities;

namespace FsCodeAplication.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        void Commit();
    }
}

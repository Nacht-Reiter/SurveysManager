using SurveysManager.DataAccess.Entities;
using System.Threading.Tasks;

namespace SurveysManager.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> SaveAsync();
    }
}

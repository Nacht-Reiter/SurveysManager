using SurveysManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveysManager.DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> DeleteAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);
    }
}

using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveysManager.BusinessLogic.Interfaces
{
    public interface ICRUDService<TEntity, TDTO> where TEntity : Entity where TDTO : BaseDTO
    {
        Task<TDTO> GetAsync(int id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> AddAsync(TDTO item);
        Task<bool> DeleteAsync(int id);
        Task<TDTO> UpdateAsync(int id, TDTO item);
    }
}

using AutoMapper;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;
using SurveysManager.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveysManager.BusinessLogic.Services
{
    public class CRUDService<TEntity, TDTO> : ICRUDService<TEntity, TDTO> where TEntity : Entity where TDTO : BaseDTO
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        public CRUDService(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }


        public virtual async Task<TDTO> AddAsync(TDTO item)
        {
            if (uow != null)
            {
                var result = await uow.Repository<TEntity>().CreateAsync(mapper.Map<TEntity>(item));
                if (result != null)
                {
                    await uow.SaveAsync();
                    return mapper.Map<TDTO>(result);
                }
            }
            return null;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            if (uow != null)
            {
                var result = await uow.Repository<TEntity>().DeleteAsync(id);
                if (result != null)
                {
                    await uow.SaveAsync();
                    return true;
                }

            }
            return false;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            if (uow != null)
            {
                var item = await uow.Repository<TEntity>().GetAllAsync();
                if (item != null)
                {
                    return mapper.Map<IEnumerable<TDTO>>(item);
                }
            }
            return null;


        }

        public virtual async Task<TDTO> GetAsync(int id)
        {
            if (uow != null)
            {
                var items = await uow.Repository<TEntity>().GetAsync(id);
                return mapper.Map<TDTO>(items);
            }
            return null;
        }

        public virtual async Task<TDTO> UpdateAsync(int id, TDTO item)
        {
            if (uow != null)
            {
                item.Id = id;
                var result = uow.Repository<TEntity>().Update(mapper.Map<TEntity>(item));
                if (result != null)
                {
                    await uow.SaveAsync();
                    return mapper.Map<TDTO>(result);
                }
            }
            return null;
        }
    }
}

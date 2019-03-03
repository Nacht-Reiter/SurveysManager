using Microsoft.EntityFrameworkCore;
using SurveysManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveysManager.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DbContext context;
        protected DbSet<TEntity> DbSet;

        public Repository(DbContext c)
        {
            this.context = c;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            TEntity entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                return DbSet.Remove(entity).Entity;
            }
            return null;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return DbSet.Update(entity).Entity;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SurveysManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveysManager.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext dbContext;
        private Dictionary<Type, object> repoStorage;

        public UnitOfWork(DbContext db)
        {
            dbContext = db;
            repoStorage = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            var type = typeof(TEntity);
            if (repoStorage.ContainsKey(type))
            {
                return repoStorage[type] as IRepository<TEntity>;
            }
            var repoInstance = new Repository<TEntity>(dbContext);
            repoStorage.Add(type, repoInstance);
            return repoInstance;
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}

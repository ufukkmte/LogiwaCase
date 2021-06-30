using LogiwaCase.Dal.Interface;
using LogiwaCase.Dal.LogiwaDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Dal.Concrete
{
    public class GenericDal<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var db = new LogiwaDbContext();
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var db = new LogiwaDbContext();
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var db = new LogiwaDbContext();
            return await db.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var db = new LogiwaDbContext();
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var db = new LogiwaDbContext();
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
        }
    }
}

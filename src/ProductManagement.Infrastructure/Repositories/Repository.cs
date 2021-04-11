using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infrastructure.Context;

namespace ProductManagement.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ProductManagementContext Context;
        protected readonly DbSet<TEntity> DbSet;
        
        protected Repository(ProductManagementContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> Get()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remove(int id)
        {
            DbSet.Remove(new TEntity {Id = id});
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
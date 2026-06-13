using ETICARET.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETICARET.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class//TEntity mutlaka bir sınıf varlığı olacak
        where TContext : DbContext, new()//TContext mutlaka Dbcontext tarafından nesnelenen bir değer olacak.
    {
        public virtual void Create(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual async Task CreateAsync(TEntity entity, CancellationToken ct = default)
        {
            await using var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity, ct);
            await context.SaveChangesAsync(ct);

        }

        public virtual void Delete(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken ct = default)
        {
            await using var context=new TContext();
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync(ct);
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken ct = default)
        {
            await using var context=new TContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync(ct)
                : await context.Set<TEntity>().Where(filter).ToListAsync(ct);
        }

        public virtual TEntity? GetById(int id)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
           await using var context= new TContext();
            return await context.Set<TEntity>().FindAsync([id], ct);
        }

        public virtual void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            await using var context = new TContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(ct);
        }

    }
}

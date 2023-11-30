using Microsoft.EntityFrameworkCore;
using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Data.Context;
using System.Linq.Expressions;

namespace ProductsRegister.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, new()
    {
        protected readonly MyDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(MyDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);

        }
        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);

        }



        public virtual void Remove(Guid id)
        {
            //var entity = await GetById(id);
            DbSet.Remove(new TEntity { Id = id });


        }



        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db.Dispose();
        }


    }
}

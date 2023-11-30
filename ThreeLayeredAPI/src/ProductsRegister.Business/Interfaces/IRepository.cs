using ProductsRegister.Business.Models;
using System.Linq.Expressions;

namespace ProductsRegister.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);
        Task<int> SaveChanges();
        //retorna o número de linhas afetadas no commit
        //O que interessa é ser MAIOR que zero
    }
}

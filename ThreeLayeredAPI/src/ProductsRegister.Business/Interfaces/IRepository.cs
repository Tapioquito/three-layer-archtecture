using ProductsRegister.Business.Models;
using System.Linq.Expressions;

namespace ProductsRegister.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
        //retorna o número de linhas afetadas no commit
        //O que interessa é ser MAIOR que zero
    }
}

using ProductsRegister.Business.Models;

namespace ProductsRegister.Business.Interfaces
{
    public interface IProductService:IDisposable
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Guid id);
    }
}

using ProductsRegister.Business.Models;

namespace ProductsRegister.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
        //retorna todos os produtos pertencentes a um fornecedor específico;

        Task<IEnumerable<Product>> GetProductsSuppliers();
        //retorna todos os produtos e seus respectivos fornecedores;
        Task<Product> GetProductSupplier(Guid id);
        //retorna um produto e seu respectivo fornecedor;
    }
}

using Microsoft.EntityFrameworkCore;
using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Data.Context;

namespace ProductsRegister.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Search(p => p.SupplierId == supplierId);
        }

        public async Task<IEnumerable<Product>> GetProductsSuppliers()
        {
            return await Db.Products
                .AsNoTracking().Include(x => x.Supplier)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await Db.Products
                .AsNoTracking().Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
            
        }
    }
}

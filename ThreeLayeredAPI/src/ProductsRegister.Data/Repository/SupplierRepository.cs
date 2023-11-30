using Microsoft.EntityFrameworkCore;
using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsRegister.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MyDbContext db) : base(db)
        {
        }
        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await Db.Suplliers.AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> GetSupplierProductAddress(Guid id)
        {
            return await Db.Suplliers.AsNoTracking()
                .Include(a => a.Address)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.SupplierId == supplierId);
        }
        public void RemoveAddressSupplier(Address address)
        {
            Db.Addresses.Remove(address);

        }

    }
}

using ProductsRegister.Business.Models;

namespace ProductsRegister.Business.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid id);
        //retorna um fornecedor e seu respectivo endereço;
        Task<Supplier> GetSupplierProductAddress(Guid id);
        //retorna um fornecedor, seu endereço e TODOS os produtos que possui
        Task<Address> GetAddressBySupplier(Guid supplierId);
        //retorna apenas o endereço através do id do fornecedor;
        Task RemoveAddressSupplier(Address address);

    }
}

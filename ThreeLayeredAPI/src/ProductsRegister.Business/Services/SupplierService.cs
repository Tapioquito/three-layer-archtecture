using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Business.Models.Validations;
using ProductsRegister.Business.Notifications;

namespace ProductsRegister.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository,
            INotifier notifier, IUnitofWork uow) : base(notifier, uow)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(Supplier supplier)
        {
            //Validar se a entidade é consistente:
            if (!ExecuteValidation(new SupplierValidation(), supplier)
               || !ExecuteValidation(new AddressValidation(), supplier.Address)) return;

            //Validar se já não existe outro fornecedor com o MESMO documento (CPF/CNPJ):


            if (_supplierRepository.Search(s => s.Document == supplier.Document).Result.Any())
            {
                Notify("Já existe um fornecedor com este documento informado");
                return;
            }

            _supplierRepository.Add(supplier);
            await Commit();
        }
        public async Task Update(Supplier supplier)
        {
            //Validar se a entidade é consistente:
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return;

            //Validar se já não existe outro fornecedor com o MESMO documento (CPF/CNPJ):
            if (_supplierRepository.Search(s => s.Document == supplier.Document
                && s.Id != s.Id).Result.Any())
            {
                Notify("Já existe um fornecedor com este documento informado");
                return;
            }
            _supplierRepository.Update(supplier);
             await Commit();
        }


        public async Task Remove(Guid id)
        {
            var supplier = await _supplierRepository.GetSupplierProductAddress(id);

            if (supplier == null)
            {
                Notify("Fornecedor não existe!");
                return;
            }

            if (supplier.Products.Any())
            {
                Notify("Fornecedor possui produtos cadastrados!");
                return;
            }
            var address = await _supplierRepository.GetAddressBySupplier(id);

            if (address != null)
            {
                _supplierRepository.RemoveAddressSupplier(address);
            }
            _supplierRepository.Remove(id);
             await Commit();
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}

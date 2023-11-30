using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Business.Models.Validations;

namespace ProductsRegister.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository,
            INotifier notifier, IUnitofWork uow) : base(notifier, uow)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;
            var existingProduct = _productRepository.GetById(product.Id);
            if (existingProduct != null)
            {
                Notify("Já existe um produto com este id informado.");
                return;
            }
            _productRepository.Add(product);
            await Commit();
        }
        public async Task Update(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;
            _productRepository.Update(product);
            await Commit();
        }


        public async Task Remove(Guid id)
        {

            _productRepository.Remove(id);
            await Commit();
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}

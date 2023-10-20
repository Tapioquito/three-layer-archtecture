using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Business.Models.Validations;

namespace ProductsRegister.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;
            var existingProduct = _productRepository.GetById(product.Id);
            if(existingProduct != null)
            {
                Notify("Já existe um produto com este id informado.");
                return;
            }
            await _productRepository.Add(product);
        }
        public async Task Update(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;
            await _productRepository.Update(product);
        }


        public async Task Remove(Guid id)
        {

            await _productRepository.Remove(id);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}

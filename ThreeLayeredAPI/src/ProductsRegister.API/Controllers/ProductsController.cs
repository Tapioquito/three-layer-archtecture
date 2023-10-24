using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsRegister.API.ViewModels;
using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using System.Net;

namespace ProductsRegister.API.Controllers
{
    [Authorize]
    [Route("api/products")]
    public class ProductsController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IProductService productService, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {

            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsSuppliers());

        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            var productViewModel = await GetProduct(id);
            if (productViewModel == null) return NotFound();
            return productViewModel;
        }
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _productRepository.Add(_mapper.Map<Product>(productViewModel));
            return CustomResponse(HttpStatusCode.Created, productViewModel);

        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                NotifyError("Os ids informados não são iguais!");
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var updateProduct = await GetProduct(id);

            updateProduct.SupplierId = productViewModel.SupplierId;
            updateProduct.Name = productViewModel.Name;
            updateProduct.Description = productViewModel.Description;
            updateProduct.Price = productViewModel.Price;
            updateProduct.isActive = productViewModel.isActive;

            await _productService.Update(_mapper.Map<Product>(updateProduct));
            return CustomResponse(HttpStatusCode.NoContent);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Remove(Guid id)
        {
            var product = await GetProduct(id);
            if (product == null) return NotFound();
            await _productService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsRegister.API.ViewModels;
using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Models;
using ProductsRegister.Business.Services;
using ProductsRegister.Data.Repository;
using System.Net;

namespace ProductsRegister.API.Controllers
{
    [Route("api/suppliers")]
    public class SupplierController : MainController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository, ISupplierService supplierService, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _supplierRepository = supplierRepository;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
        {

            var supplier = await GetSupplierProductsAddress(id);
            if (supplier == null) return NotFound();
            return supplier;
        }
        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _supplierRepository.Add(_mapper.Map<Supplier>(supplierViewModel));
            return CustomResponse(HttpStatusCode.Created, supplierViewModel);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, SupplierViewModel supplierViewModel)
        {

            if (id != supplierViewModel.Id)
            {
                NotifyError("Os ids informados não são iguais!");
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _supplierRepository.Update(_mapper.Map<Supplier>(supplierViewModel));
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Remove(Guid id)
        {
            await _supplierRepository.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<SupplierViewModel> GetSupplierProductsAddress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductAddress(id));
        }
    }
}

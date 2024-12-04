using AutoMapper;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;

namespace EShoppingApp.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<int, Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IRepository<int, Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(SupplierDTO supplier)
        {
            var suppliers = _mapper.Map<Supplier>(supplier);

            var addedSupplier = await _supplierRepository.Add(suppliers);


            return addedSupplier.Id;
        }

        public async Task<Supplier> Get(int supplierId)
        {
            var supplier = await _supplierRepository.Get(supplierId);
            return supplier;
        }
    }
}

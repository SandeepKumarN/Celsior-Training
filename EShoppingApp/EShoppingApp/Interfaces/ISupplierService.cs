using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Interfaces
{
    public interface ISupplierService
    {
        Task<int> Add(SupplierDTO supplier);
        Task<Supplier> Get(int supplierId);
    }
}

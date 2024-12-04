using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Interfaces
{
    public interface IAdminService
    {
        Task<int> Add(AdminDTO admin);
        Task<Admin> Get(int adminId);
        Task<Admin> Update(int adminId, AdminUpdateDTO adminDto);
        Task<bool> Delete(int adminId);
    }
}

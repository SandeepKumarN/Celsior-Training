using AutoMapper;
using Castle.Core.Resource;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;
using MailKit.Search;

namespace EShoppingApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<int, Admin> _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IRepository<int, Admin> adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(AdminDTO admin)
        {
            var admins = _mapper.Map<Admin>(admin);
            
            var addedAdmin = await _adminRepository.Add(admins);

            
            return addedAdmin.Id;
        }

        public async Task<bool> Delete(int adminId)
        {
            var deletedAdmin = await _adminRepository.Delete(adminId);

            // Return true if the deletion was successful
            return deletedAdmin != null;
        }

        public async Task<Admin> Get(int adminId)
        {
            var admin = await _adminRepository.Get(adminId);
            return admin;
        }

        public async Task<Admin> Update(int adminId, AdminUpdateDTO adminDto)
        {
            var admin = new Admin
            {
                Name = adminDto.Name,
                Phone = adminDto.Phone,
                Email = adminDto.Email
            };
            var updatedAdmin = await _adminRepository.Update(adminId, admin);
            return updatedAdmin;
        }
    }
}

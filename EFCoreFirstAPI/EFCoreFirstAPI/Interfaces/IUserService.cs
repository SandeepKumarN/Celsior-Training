using EFCoreFirstAPI.Models.DTOs;
using EFCoreFirstAPI.Services;

namespace EFCoreFirstAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDTO> Autheticate(LoginRequestDTO loginUser);
        public Task<LoginResponseDTO> Register(UserCreateDTO registerUser);

    }
}

using JWTAuthServer.Core.DTOs;
using SharedLibrary.DTOs;

namespace JWTAuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string name);
    }
}

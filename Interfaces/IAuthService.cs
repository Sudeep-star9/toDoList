using Microsoft.AspNetCore.Identity;
using toDoList.Dtos.UserDtos;

namespace toDoList.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}

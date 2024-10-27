using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using toDoList.Dtos.UserDtos;

namespace toDoList.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);

    }
}

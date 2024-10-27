using Microsoft.AspNetCore.Identity;
using toDoList.Dtos.UserDtos;
using toDoList.Interfaces;

namespace toDoList.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            return await _authRepository.RegisterAsync(registerDto);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            return await _authRepository.LoginAsync(loginDto);
        }
    }
}

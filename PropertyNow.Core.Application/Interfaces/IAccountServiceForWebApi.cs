using PropertyNow.Core.Application.DTOs.User;
using PropertyNow.Core.Domain.Common.Enums;
namespace PropertyNow.Core.Application.Interfaces
{
    public interface IAccountServiceForWebApi : IBaseAccountService
    {
        Task<LoginResponseForApiDTO> AuthenticateAsync(LoginDto loginDto);
        Task<bool> ConfirmAccountAsync(string userId, string token);
        Task<UserResponseDto> ForgotPasswordWithTokenAsync(ForgotPasswordWithTokenDto request);
        Task<(bool Success, string? ErrorMessage)> CreateUserAsync(CreateUserRequestDto request, Roles rol);
        Task UpdateUserAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(string userId);
    }
}
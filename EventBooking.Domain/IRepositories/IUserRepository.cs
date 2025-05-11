using EventBooking.Domain.Dtos;

namespace EventBooking.Domain.IRepositories;

public interface IUserRepository
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<string> AddRoleAsync(AddRoleDto addRoleDto);
}
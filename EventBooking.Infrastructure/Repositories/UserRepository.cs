using EventBooking.Domain.Common;
using EventBooking.Domain.Constants;
using EventBooking.Domain.Dtos;
using EventBooking.Domain.Entities;
using EventBooking.Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.Marshalling;

namespace EventBooking.Infrastructure.Repositories;

public class UserRepository(UserManager<User> userManager, IJwtService jwtService,RoleManager<IdentityRole> roleManager) : IUserRepository
{
    public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
    {
        if (await userManager.FindByEmailAsync(registerDto.Email) is not null)
            return new AuthResponseDto { Message = "Email is already registered" };

        if (await userManager.FindByNameAsync(registerDto.UserName) is not null )
            return new AuthResponseDto { Message = "User name is already registered" };

        var user = new User
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            var errors = string.Empty;

            foreach (var error in result.Errors)
            {
                errors += $"{error.Description},";
            }
           
            return new AuthResponseDto { Message = errors};
        }
        await userManager.AddToRoleAsync(user, UserRoles.User);

        var jwtSecurityToken =await jwtService.CreateJwtToken(user);

        return new AuthResponseDto
        {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Roles = new List<string> { "User" },
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };

    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        var authResponseDto = new AuthResponseDto();

        var user = await userManager.FindByEmailAsync(loginDto.Email);

        if(user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            authResponseDto.Message = "Email or Passowed is incorect!";
            return authResponseDto;
        }

        var roles = await userManager.GetRolesAsync(user);
        
        var securityToken = await jwtService.CreateJwtToken(user);
     
        authResponseDto.IsAuthenticated = true;
        authResponseDto.Email = user.Email!;
        authResponseDto.Username = user.UserName!;
        authResponseDto.Token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        authResponseDto.ExpiresOn = securityToken.ValidTo;
        authResponseDto.Roles = roles.ToList();
        
        
        return authResponseDto;
    }

    public async Task<string> AddRoleAsync(AddRoleDto addRoleDto)
    {
        var user = await userManager.FindByIdAsync(addRoleDto.UserId);

        if (user == null || !await roleManager.RoleExistsAsync(addRoleDto.Role))
            return "Invalid user id or role";

        if (await userManager.IsInRoleAsync(user, addRoleDto.Role))
            return "User already assigned to this role";

        var result = await userManager.AddToRoleAsync(user, addRoleDto.Role);

       return result.Succeeded ? string.Empty : "Somthing went wrong";

    }
}

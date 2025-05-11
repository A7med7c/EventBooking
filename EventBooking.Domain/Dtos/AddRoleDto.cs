using System.ComponentModel.DataAnnotations;

namespace EventBooking.Domain.Dtos;

public class AddRoleDto
{
    [Required]
    public string UserId { get; set; } = default!;
    [Required]
    public string Role { get; set; } = default!;
}

using System.ComponentModel.DataAnnotations;

namespace  EventBooking.Domain.Dtos;


public class LoginDto
{
    [Required(ErrorMessage = "Email is required."), StringLength(80)]
    public string Email { get; set; } = default!;
    [Required(ErrorMessage = "Password is required."), StringLength(250)]
    public string Password { get; set; } = default!;
}

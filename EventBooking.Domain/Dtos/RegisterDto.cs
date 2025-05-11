using System.ComponentModel.DataAnnotations;

namespace  EventBooking.Domain.Dtos;


public class RegisterDto
{
    [Required(ErrorMessage = "FirstName name is required."),StringLength(100)]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "LastName name is required."), StringLength(100)]
    public string LastName { get; set; } = default!;
    [Required(ErrorMessage = "Email is required."), StringLength(80)]
    public string Email { get; set; } = default!;
    [Required(ErrorMessage = "UserName is required."), StringLength(50)]
    public string UserName { get; set; } = default!;
    [Required(ErrorMessage = "Password is required."), StringLength(250)]
    public string Password { get; set; } = default!;
  

}

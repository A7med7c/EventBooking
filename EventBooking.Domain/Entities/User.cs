using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Domain.Entities;

public class User : IdentityUser
{
    [Required(ErrorMessage = "FirstName name is required.")]
    public string FirstName { get; set; } = default!;
    
    [Required(ErrorMessage = "LastName name is required.")]
    public string LastName { get; set; } = default!;
    public List<Booking> Bookings { get; set; } = new();
}
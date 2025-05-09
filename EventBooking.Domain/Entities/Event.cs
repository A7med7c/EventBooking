using System.ComponentModel.DataAnnotations;

namespace EventBooking.Domain.Entities;

public class Event
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters.")]
    public string Name { get; set; } = default!;

    [StringLength(500, ErrorMessage = "Event description cannot exceed 500 characters.")]
    public string Description { get; set; } = default!;

    [Required(ErrorMessage = "Event date is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Event venue is required.")]
    public string Venue { get; set; } = default!;

    [Range(0, double.MaxValue, ErrorMessage = "Event price cannot be negative.")]
    public decimal Price { get; set; }

    [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
    public string ImageUrl { get; set; } = default!;

    public List<Booking> Bookings { get; set; } = new();
    public int CategoryId { get; set; }
}

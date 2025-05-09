namespace EventBooking.Domain.Entities;
public class Booking
{

    public int Id { get; set; }
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    public int EventId { get; set; }
    public string UserId { get; set; } = default!;

}
namespace EventBooking.Domain.Common;

public class JWT
{
    public string SecretKey { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public double DurationInDays { get; set; }
}

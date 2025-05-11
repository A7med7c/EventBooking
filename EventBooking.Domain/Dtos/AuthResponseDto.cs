namespace EventBooking.Domain.Dtos;

public class AuthResponseDto
{
    public string? Message { get; set; } 
    public bool IsAuthenticated { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public List<string> Roles { get; set; } = default!;
    public string Token { get; set; } = default!;
    public DateTime ExpiresOn { get; set; }
}

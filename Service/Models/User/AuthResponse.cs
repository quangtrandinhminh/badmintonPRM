

namespace Service.Models.User;

public class AuthResponse
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public int Role { get; set; }
    public string Token { get; set; } = null!;
}
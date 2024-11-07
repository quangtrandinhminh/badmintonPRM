using System.ComponentModel.DataAnnotations;

namespace Service.Models.User;

public class SignUpRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    [Range(1,4)]
    public int Role { get; set; }
}
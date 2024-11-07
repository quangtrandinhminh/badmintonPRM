using System.ComponentModel.DataAnnotations;
using Repository.Models;

namespace Service.Models;

public class PrimaryRequest
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$")]
    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int? Entity1Id { get; set; }
}
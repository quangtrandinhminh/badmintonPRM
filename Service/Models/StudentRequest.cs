using Repository.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Service.Utils;

namespace Service.Models;

public class StudentRequest
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$")]
    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }
    public int? GroupId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class Yard
{
    [Key]
    public int YardId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int? ProvinceId { get; set; }
    public TimeOnly? OpenTime { get; set; }
    public TimeOnly? CloseTime { get; set; }
    public string? Description { get; set; }
    public int OwnerId { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("OwnerId")]
    public virtual User Owner { get; set; } = null!;
    public virtual ICollection<Slot?> Slots { get; set; } = null!;
    public virtual ICollection<YardImage?> YardImages { get; set; } = null!;
}
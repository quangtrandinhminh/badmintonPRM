using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class Yard
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int ProvinceId { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int OwnerId { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("OwnerId")]
    public virtual User Owner { get; set; } = null!;
    public virtual ICollection<Slot> Slots { get; set; } = null!;
}
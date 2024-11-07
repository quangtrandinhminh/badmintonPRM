using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class Slot
{
    public int Id { get; set; }
    public int YardId { get; set; }
    public double Price { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("YardId")]
    public virtual Yard Yard { get; set; } = null!;
}
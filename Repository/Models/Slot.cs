using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class Slot
{
    [Key]
    public int SlotId { get; set; }
    public int YardId { get; set; }
    public double Price { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("YardId")]
    public virtual Yard Yard { get; set; } = null!;
    public virtual ICollection<BookingOrders> BookingOrders { get; set; } = null!;
}